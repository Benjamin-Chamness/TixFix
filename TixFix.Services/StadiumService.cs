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

        public StadiumDetail GetStadiumById(int id)
        {
            Stadium stadiumToGet = _context.Stadiums.Single(s => s.StadiumId == id);
            return CreateStadiumDetail(stadiumToGet);
        }

        //Helper Methods
        public StadiumListItem CreateStadiumListItem(Stadium model)
        {
            return new StadiumListItem()
            {
                StadiumId = model.StadiumId,
                StadiumName = model.StadiumName,
                Location = model.Location,
                Opponent = model.Opponent
            };
        }

        public StadiumDetail CreateStadiumDetail(Stadium model)
        {
            return new StadiumDetail()
            {
                StadiumName = model.StadiumName,
                Location = model.Location,
                Opponent = model.Opponent
            };
        }

    }
}