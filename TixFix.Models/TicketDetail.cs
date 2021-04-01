using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TixFix.Models
{
    public class TicketDetail
    {
        public int TicketId { get; set; }

        
        [Display(Name = "Opponent")]
        public int OpponentId { get; set; }

        [Display(Name = "Seat Number")]
        public int SeatId { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime DateOfGame { get; set; }

        [Required]
        public bool IsAvailable { get; set; }
    }
}
