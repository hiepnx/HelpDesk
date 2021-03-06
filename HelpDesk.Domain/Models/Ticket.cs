using System;
using System.Collections.Generic;
using HelpDesk.Domain.Utilities;

namespace HelpDesk.Domain.Models
{
    public partial class Ticket
    {
        public Ticket()
        {
            this.TicketAttachments = new List<TicketAttachment>();
            this.TicketComments = new List<TicketComment>();
            this.TicketTags = new List<TicketTag>();
        }

        public int TicketId { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public bool IsHtml { get; set; }
        public string TagList { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string Owner { get; set; }
        public string AssignedTo { get; set; }
        public string CurrentStatus { get; set; }
        public System.DateTime CurrentStatusDate { get; set; }
        public string CurrentStatusSetBy { get; set; }
        public string LastUpdateBy { get; set; }
        public System.DateTime LastUpdateDate { get; set; }
        public string Priority { get; set; }
        public bool AffectsCustomer { get; set; }
        public bool PublishedToKb { get; set; }
        public byte[] Version { get; set; }
        public virtual ICollection<TicketAttachment> TicketAttachments { get; set; }
        public virtual ICollection<TicketComment> TicketComments { get; set; }
        public virtual ICollection<TicketTag> TicketTags { get; set; }

        
        public string HtmlDetails
        {
            get
            {
                var md = new Markdown();
                return (IsHtml) ? Details : md.Transform(Details, false);
            }
        }
        internal string[] GetNotificationSubscribers()
        {
            var subs = new List<string>();
            if (!string.IsNullOrEmpty(PreviousOwner) && !PreviousOwner.Equals(Owner, StringComparison.InvariantCultureIgnoreCase))
            {
                subs.Add(PreviousOwner);
            }
            if (!string.IsNullOrEmpty(PreviousAssignedUser) && !PreviousAssignedUser.Equals(AssignedTo, StringComparison.InvariantCultureIgnoreCase))
            {
                subs.Add(PreviousAssignedUser);
            }
            if (!string.IsNullOrEmpty(Owner))
            {
                subs.Add(Owner);
            }
            if (!string.IsNullOrEmpty(AssignedTo))
            {
                subs.Add(AssignedTo);
            }
            return subs.ToArray();
        }


        internal string PreviousOwner { get; set; }
        internal string PreviousAssignedUser { get; set; }

        //protected override void OnPropertyChanging(string property)
        //{
        //    if (property == "AssignedTo")
        //    {
        //        PreviousAssignedUser = AssignedTo;
        //    }
        //    if (property == "Owner")
        //    {
        //        PreviousOwner = Owner;
        //    }
        //    base.OnPropertyChanging(property);
        //}


    }
}
