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
        [Required]
        public string StadiumName { get; set; }

        [ForeignKey(nameof(Opponent))]
        public int EventId { get; set; }
        public virtual Opponent Opponent { get; set; }

    }
}
