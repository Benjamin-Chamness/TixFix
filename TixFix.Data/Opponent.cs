﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TixFix.Data
{
    public class Opponent
    {
        [Key]
        public int EventId { get; set; }
       
        [Required]
        public string Name { get; set; }

        public virtual Stadium Stadium { get; set; }


             
    }
}
