using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TixFix.Data;
using TixFix.Models;

namespace TixFix.Services
{
    public class OpponentService
    {
        private readonly Guid _userId;
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public OpponentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateOpponent(OpponentCreate model)
        {
            var entity = new Opponent()
            {
                OpponentId = model.OpponentId,
                Name = model.Name
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Opponents.Add(entity);
                return ctx.SaveChanges() > 0;
            }
        }

        public List<OpponentListItem> GetOpponents()
        {
            List<Opponent> opponents = _context.Opponents.ToList();
            List<OpponentListItem> opponentListItems = opponents.Select(o => CreateOpponentListItem(o)).ToList();
            return opponentListItems;
        }

        //Helper Methods
        public OpponentListItem CreateOpponentListItem(Opponent model)
        {
            return new OpponentListItem()
            {
                OpponentId = model.OpponentId,
                Name = model.Name
            };
        }
    }
}

                
            
            

