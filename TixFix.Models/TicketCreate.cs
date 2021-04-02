using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TixFix.Data;

namespace TixFix.Models
{
    public class TicketCreate
    {
        [Required]
        public int TicketId { get; set; }
        
        [Display(Name = "Opponent")]
        public int OpponentId { get; set; }

        public virtual Opponent Opponent { get; set; }

        [Display(Name = "Seat Number")]
        public int SeatId { get; set; }

        public decimal Price { get; set; }

        [Display(Name = "Game Day")]
        public DateTime DateOfGame { get; set; }

        public bool IsAvailable { get; set; }
    }
}
