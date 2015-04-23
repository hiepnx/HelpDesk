using System;
using System.Collections.Generic;

namespace HelpDesk.Domain.Models
{
    public partial class TicketEventNotification
    {
        public int TicketId { get; set; }
        public int CommentId { get; set; }
        public string NotifyUser { get; set; }
        public string NotifyUserDisplayName { get; set; }
        public string NotifyEmail { get; set; }
        public string NotifyUserReason { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int DeliveryAttempts { get; set; }
        public Nullable<System.DateTime> LastDeliveryAttemptDate { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> NextDeliveryAttemptDate { get; set; }
        public string EventGeneratedByUser { get; set; }
        public virtual TicketComment TicketComment { get; set; }
    }
}
