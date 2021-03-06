using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TixFix.Data;

namespace TixFix.Models
{
    public class TicketDetail
    {
        public int TicketId { get; set; }
        
        
        public virtual Opponent Opponent { get; set; }

        public virtual Stadium Stadium { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime DateOfGame { get; set; }

        [Required]
        public bool IsAvailable { get; set; }
    }
}
