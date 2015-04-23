using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HelpDesk.Domain.Models.Mapping
{
    public class TicketEventNotificationMap : EntityTypeConfiguration<TicketEventNotification>
    {
        public TicketEventNotificationMap()
        {
            // Primary Key
            this.HasKey(t => new { t.TicketId, t.CommentId, t.NotifyUser });

            // Properties
            this.Property(t => t.TicketId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.CommentId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.NotifyUser)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.NotifyUserDisplayName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.NotifyEmail)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.NotifyUserReason)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Status)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.EventGeneratedByUser)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("TicketEventNotifications");
            this.Property(t => t.TicketId).HasColumnName("TicketId");
            this.Property(t => t.CommentId).HasColumnName("CommentId");
            this.Property(t => t.NotifyUser).HasColumnName("NotifyUser");
            this.Property(t => t.NotifyUserDisplayName).HasColumnName("NotifyUserDisplayName");
            this.Property(t => t.NotifyEmail).HasColumnName("NotifyEmail");
            this.Property(t => t.NotifyUserReason).HasColumnName("NotifyUserReason");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.DeliveryAttempts).HasColumnName("DeliveryAttempts");
            this.Property(t => t.LastDeliveryAttemptDate).HasColumnName("LastDeliveryAttemptDate");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.NextDeliveryAttemptDate).HasColumnName("NextDeliveryAttemptDate");
            this.Property(t => t.EventGeneratedByUser).HasColumnName("EventGeneratedByUser");

            // Relationships
            this.HasRequired(t => t.TicketComment)
                .WithMany(t => t.TicketEventNotifications)
                .HasForeignKey(d => new { d.TicketId, d.CommentId });

        }
    }
}
