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
                    DateOfGame = model.DateOfGame,
                    IsAvailable = model.IsAvailable
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
                                    DateOfGame = t.DateOfGame,
                                    IsAvailable = t.IsAvailable
                                }
                        );

                return query.ToArray();
            }
        }

        public TicketDetail GetTicketById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Tickets
                        .Single(t => t.TicketId == id && t.OwnerId == _userId);
                return
                    new TicketDetail
                    {
                        TicketId = entity.TicketId,
                        OpponentId = entity.OpponentId,
                        Price = entity.Price,
                        DateOfGame = entity.DateOfGame,
                        IsAvailable = entity.IsAvailable
                    };
            }
        }

        public bool UpdateTicket(TicketEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                            .Tickets
                            .Single(t => t.TicketId == model.TicketId && t.OwnerId == _userId);

                entity.TicketId = model.TicketId;
                entity.Price = model.Price;
                entity.DateOfGame = model.DateOfGame;
                entity.IsAvailable = model.IsAvailable;

                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteTicket(int ticketId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Tickets
                        .Single(t => t.TicketId == ticketId && t.OwnerId == _userId);

                ctx.Tickets.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
