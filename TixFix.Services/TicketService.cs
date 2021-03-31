using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TixFix.Data;
using TixFix.Models;

namespace TixFix.Services
{
    public class TicketService
    {
        private readonly Guid _userId;

        public TicketService(Guid userId)
        {
            _userId = userId;
        }


        public bool CreateTicket(TicketCreate model)
        {
            var entity =
                new Ticket()
                {
                    OwnerId = _userId,
                    TicketId = model.TicketId,
                    OpponentId = model.OpponentId,
                    Price = model.Price,
                    DateOfGame = model.DateOfGame
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Tickets.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TicketListItem> GetTickets()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Tickets
                        .Where(t => t.OwnerId == _userId)
                        .Select(
                            t =>
                                new TicketListItem
                                {
                                    TicketId = t.TicketId,
                                    OpponentId = t.OpponentId,
                                    Price = t.Price,
                                    DateOfGame = t.DateOfGame
                                }
                        );

                return query.ToArray();
            }
        }
    }
}
