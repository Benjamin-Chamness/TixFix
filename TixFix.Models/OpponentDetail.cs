using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TixFix.Data;

namespace TixFix.Models
{
    public class OpponentDetail
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public virtual Stadium Stadium { get; set; }
        


    }
}
