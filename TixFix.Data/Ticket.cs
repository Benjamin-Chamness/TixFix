using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime DateOfGame { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        [ForeignKey(nameof(Opponent))]
        [Display(Name= "Opponent")]
        public int OpponentId { get; set; }
        public virtual Opponent Opponent { get; set; }


        [ForeignKey(nameof(Stadium))]
        [Display(Name = "Stadium")]
        public int StadiumId { get; set; }
        public virtual Stadium Stadium { get; set; }
                
        


    }
}
