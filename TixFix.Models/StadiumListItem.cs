using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TixFix.Data;

namespace TixFix.Models
{
    public class StadiumListItem
    {
        public int StadiumId { get; set; }

        [Display(Name="Stadium")]
        public string StadiumName { get; set; }
        //public virtual Opponent Opponent { get; set; }
        public string Location { get; set; }
        
        
        
    }
}
