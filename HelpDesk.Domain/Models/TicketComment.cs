using System;
using System.Collections.Generic;

namespace HelpDesk.Domain.Models
{
    public partial class TicketComment
    {
        public TicketComment()
        {
            this.TicketEventNotifications = new List<TicketEventNotification>();
        }

        public int TicketId { get; set; }
        public int CommentId { get; set; }
        public string CommentEvent { get; set; }
        public string Comment { get; set; }
        public bool IsHtml { get; set; }
        public string CommentedBy { get; set; }
        public System.DateTime CommentedDate { get; set; }
        public byte[] Version { get; set; }
        public virtual Ticket Ticket { get; set; }
        public virtual ICollection<TicketEventNotification> TicketEventNotifications { get; set; }
    }
}
