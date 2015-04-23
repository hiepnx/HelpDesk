using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HelpDesk.Domain.Models.Mapping
{
    public class TicketCommentMap : EntityTypeConfiguration<TicketComment>
    {
        public TicketCommentMap()
        {
            // Primary Key
            this.HasKey(t => new { t.TicketId, t.CommentId });

            // Properties
            this.Property(t => t.TicketId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.CommentId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.CommentEvent)
                .HasMaxLength(500);

            this.Property(t => t.CommentedBy)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Version)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(8)
                .IsRowVersion();

            // Table & Column Mappings
            this.ToTable("TicketComments");
            this.Property(t => t.TicketId).HasColumnName("TicketId");
            this.Property(t => t.CommentId).HasColumnName("CommentId");
            this.Property(t => t.CommentEvent).HasColumnName("CommentEvent");
            this.Property(t => t.Comment).HasColumnName("Comment");
            this.Property(t => t.IsHtml).HasColumnName("IsHtml");
            this.Property(t => t.CommentedBy).HasColumnName("CommentedBy");
            this.Property(t => t.CommentedDate).HasColumnName("CommentedDate");
            this.Property(t => t.Version).HasColumnName("Version");

            // Relationships
            this.HasRequired(t => t.Ticket)
                .WithMany(t => t.TicketComments)
                .HasForeignKey(d => d.TicketId);

        }
    }
}
