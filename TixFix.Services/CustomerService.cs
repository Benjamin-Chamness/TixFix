using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TixFix.Data;
using TixFix.Models;

namespace TixFix.Services
{
    public class CustomerService
    {
        private readonly Guid _userId;

        public CustomerService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCustomer(CustomerCreate model)
        {
            var entity = new Customer()
            {
                OwnerId = _userId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Customers.Add(entity);
                return ctx.SaveChanges()== 1;
            }
        }

        public IEnumerable<CustomerListItem> GetCustomers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Customers.Where(c => c.OwnerId == _userId)
                    .Select(c => new CustomerListItem
                    {
                        CustomerId = c.CustomerId,
                        FirstName = c.FirstName,
                        LastName = c.LastName
                    });

                return query.ToArray();
            }
        }
    }
}
