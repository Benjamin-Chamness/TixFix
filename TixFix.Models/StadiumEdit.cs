using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TixFix.Models
{
    public class StadiumEdit
    {
        public int StadiumId { get; set; }
        public int EventId { get; set; }
        public string Location { get; set; }
        public string StadiumName { get; set; }
    }
}
