using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TixFix.Data;

namespace TixFix.Models
{
    public class StadiumCreate
    {
        public int StadiumId { get; set; }
        public string StadiumName { get; set; }
        public virtual Opponent Opponent { get; set; }
    }
}
