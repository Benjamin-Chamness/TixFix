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
        
        public virtual Opponent Opponent { get; set; }

        public virtual Stadium Stadium { get; set; }

        public decimal Price { get; set; }

        [Display(Name = "Game Day")]
        public DateTime DateOfGame { get; set; }

        public bool IsAvailable { get; set; }
    }
}
