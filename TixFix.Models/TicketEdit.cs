using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TixFix.Models
{
    public class TicketEdit
    {
        public int TicketId { get; set; }
        public decimal Price { get; set; }
        public DateTime DateOfGame { get; set; }
        public bool IsAvailable { get; set; }
    }
}
