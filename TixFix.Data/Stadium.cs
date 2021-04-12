using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TixFix.Data
{
    public class Stadium
    {
        [Key]
        public int StadiumId { get; set; }
        public virtual Opponent Opponent { get; set; }

        [Required]
        [Display(Name ="Stadium")]
       public string StadiumName { get; set; }

        public string Location { get; set; }

       

    }
}
