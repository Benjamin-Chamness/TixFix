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

        public bool UpdateStadium(StadiumEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Stadiums.SingleOrDefault(s => s.StadiumId == model.StadiumId);
                entity.StadiumId = model.StadiumId;
                entity.Location = model.Location;
                entity.StadiumName = model.StadiumName;

                return ctx.SaveChanges() > 0;
            }
        }

        public bool DeleteStadium(int stadiumId)
        {
            Stadium stadiumToDelete = _context.Stadiums.SingleOrDefault(s => s.StadiumId == stadiumId);
            _context.Stadiums.Remove(stadiumToDelete);
            return _context.SaveChanges() > 0;
        }

        //Helper Methods
        public StadiumListItem CreateStadiumListItem(Stadium model)
        {
            return new StadiumListItem()
            {
                StadiumId = model.StadiumId,
                StadiumName = model.StadiumName,
                Location = model.Location
                
            };
        }

        public StadiumDetail CreateStadiumDetail(Stadium model)
        {
            return new StadiumDetail()
            {
                StadiumId = model.StadiumId,
                StadiumName = model.StadiumName,
                Location = model.Location
            };
        }

    }
}