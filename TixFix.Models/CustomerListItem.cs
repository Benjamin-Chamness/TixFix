﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TixFix.Data;

namespace TixFix.Models
{
    public class CustomerListItem
    {
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [ForeignKey(nameof(Data.TicketDisplay))]
        public List<Data.TicketDisplay> ListOfTickets { get; set; }
        public virtual Data.TicketDisplay Tickets { get; set; }

    }
}
