using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TixFix.Data
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }
                
        [Display(Name ="Opponent")]
        public int OpponentId { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime DateOfGame { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        //public List<Seat> Seats { get; set; }

    }
}
