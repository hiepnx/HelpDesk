using System;
using System.Collections.Generic;

namespace HelpDesk.Domain.Models
{
    public partial class TicketTag
    {
        public int TicketTagId { get; set; }
        public string TagName { get; set; }
        public int TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}
