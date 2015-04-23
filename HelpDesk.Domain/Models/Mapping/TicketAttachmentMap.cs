using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HelpDesk.Domain.Models.Mapping
{
    public class TicketAttachmentMap : EntityTypeConfiguration<TicketAttachment>
    {
        public TicketAttachmentMap()
        {
            // Primary Key
            this.HasKey(t => t.FileId);

            // Properties
            this.Property(t => t.FileName)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.FileType)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.UploadedBy)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.FileContents)
                .IsRequired();

            this.Property(t => t.FileDescription)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("TicketAttachments");
            this.Property(t => t.TicketId).HasColumnName("TicketId");
            this.Property(t => t.FileId).HasColumnName("FileId");
            this.Property(t => t.FileName).HasColumnName("FileName");
            this.Property(t => t.FileSize).HasColumnName("FileSize");
            this.Property(t => t.FileType).HasColumnName("FileType");
            this.Property(t => t.UploadedBy).HasColumnName("UploadedBy");
            this.Property(t => t.UploadedDate).HasColumnName("UploadedDate");
            this.Property(t => t.FileContents).HasColumnName("FileContents");
            this.Property(t => t.FileDescription).HasColumnName("FileDescription");
            this.Property(t => t.IsPending).HasColumnName("IsPending");

            // Relationships
            this.HasOptional(t => t.Ticket)
                .WithMany(t => t.TicketAttachments)
                .HasForeignKey(d => d.TicketId);

        }
    }
}
