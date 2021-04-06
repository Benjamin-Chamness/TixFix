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

        /*public bool CreateOpponent(OpponentCreate model)
        {
            var entity = new Opponent()
            {
                OpponentId = model.OpponentId,
                Name = model.Name
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Opponents.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }*/

        public List<OpponentListItem> GetOpponents()
        {
            List<Opponent> opponents = _context.Opponents.ToList();
            List<OpponentListItem> opponentListItems = opponents.Select(o => CreateOpponentListItem(o)).ToList();
            return opponentListItems;
        }

        public OpponentDetail GetOpponentById(int id)
        {
            
                Opponent opponentToGet = _context.Opponents.Single(o => o.OpponentId == id);
                return CreateOpponentDetail(opponentToGet);
        }

        public bool UpdateOpponent(OpponentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Opponents.Single(o => o.OpponentId == model.OpponentId);
                entity.OpponentId = model.OpponentId;
                entity.Name = model.Name;

                return ctx.SaveChanges() > 0;
            }
        }

        public bool DeleteOpponent(int opponentId)
        {
            Opponent opponentToDelete = _context.Opponents.Single(o => o.OpponentId == opponentId);
            _context.Opponents.Remove(opponentToDelete);
            return _context.SaveChanges() > 0;
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

        public OpponentDetail CreateOpponentDetail(Opponent model)
        {
            return new OpponentDetail()
            {
                OpponentId = model.OpponentId,
                Name = model.Name
            };
        }
    }
}

                
            
            

