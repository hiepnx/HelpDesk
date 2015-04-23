using System;
using System.Collections.Generic;

namespace HelpDesk.Domain.Models
{
    public partial class TicketAttachment
    {
        public Nullable<int> TicketId { get; set; }
        public int FileId { get; set; }
        public string FileName { get; set; }
        public int FileSize { get; set; }
        public string FileType { get; set; }
        public string UploadedBy { get; set; }
        public System.DateTime UploadedDate { get; set; }
        public byte[] FileContents { get; set; }
        public string FileDescription { get; set; }
        public bool IsPending { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}
