using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TixFix.Models
{
    public class OpponentCreate
    {
        public int OpponentId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
