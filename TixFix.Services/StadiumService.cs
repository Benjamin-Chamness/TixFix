using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TixFix.Data;
using TixFix.Models;

namespace TixFix.Services
{
    public class StadiumService
    {
        private readonly Guid _userId;
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public StadiumService(Guid userId)
        {
            _userId = userId;
        }

        public List<StadiumListItem> GetStadiums()
        {
            List<Stadium> stadiums = _context.Stadiums.ToList();
            List<StadiumListItem> stadiumListItems = stadiums.Select(s => CreateStadiumListItem(s)).ToList();
            return stadiumListItems;
        }

        //Helper Methods
        public StadiumListItem CreateStadiumListItem(Stadium model)
        {
            return new StadiumListItem()
            {
                EventId = model.EventId,
                StadiumName = model.StadiumName
            };
        }

    }
}