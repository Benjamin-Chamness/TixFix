using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TixFix.Data;

namespace TixFix.Models
{
    public class OpponentListItem
    {
        public int EventId { get; set; }
        public string Stadium { get; set; }

        [Required]
        public string Name { get; set; }

        //[Display (Name= "Ticket List")]
        //public virtual List<Ticket> Tickets { get; set; }
    }
}
