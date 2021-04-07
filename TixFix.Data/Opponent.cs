using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TixFix.Data
{
    public class Opponent
    {
        [Key]
        public int EventId { get; set; }
       
        public string Stadium { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey(nameof(TicketDisplay))]
        [Display(Name = "Game Information")]
        public string TicketDisplay { get; set; }
    }
}
