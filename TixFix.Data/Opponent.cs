using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TixFix.Data
{
    public class Opponent
    {
        [Key]
        public int OpponentId { get; set; }
        //public Guid OwnerId { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Ticket List")]
        public virtual List<Ticket> Tickets { get; set; }
    }
}
