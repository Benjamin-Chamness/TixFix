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
        
        [Required]
        public string Name { get; set; }

        
    }
}
