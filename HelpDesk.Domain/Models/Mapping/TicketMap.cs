using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HelpDesk.Domain.Models.Mapping
{
    public class TicketMap : EntityTypeConfiguration<Ticket>
    {
        public TicketMap()
        {
            // Primary Key
            this.HasKey(t => t.TicketId);

            // Properties
            this.Property(t => t.Type)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Category)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.Details)
                .IsRequired();

            this.Property(t => t.TagList)
                .HasMaxLength(100);

            this.Property(t => t.CreatedBy)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Owner)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.AssignedTo)
                .HasMaxLength(100);

            this.Property(t => t.CurrentStatus)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.CurrentStatusSetBy)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.LastUpdateBy)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Priority)
                .HasMaxLength(25);

            this.Property(t => t.Version)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(8)
                .IsRowVersion();

            // Table & Column Mappings
            this.ToTable("Tickets");
            this.Property(t => t.TicketId).HasColumnName("TicketId");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.Category).HasColumnName("Category");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Details).HasColumnName("Details");
            this.Property(t => t.IsHtml).HasColumnName("IsHtml");
            this.Property(t => t.TagList).HasColumnName("TagList");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.Owner).HasColumnName("Owner");
            this.Property(t => t.AssignedTo).HasColumnName("AssignedTo");
            this.Property(t => t.CurrentStatus).HasColumnName("CurrentStatus");
            this.Property(t => t.CurrentStatusDate).HasColumnName("CurrentStatusDate");
            this.Property(t => t.CurrentStatusSetBy).HasColumnName("CurrentStatusSetBy");
            this.Property(t => t.LastUpdateBy).HasColumnName("LastUpdateBy");
            this.Property(t => t.LastUpdateDate).HasColumnName("LastUpdateDate");
            this.Property(t => t.Priority).HasColumnName("Priority");
            this.Property(t => t.AffectsCustomer).HasColumnName("AffectsCustomer");
            this.Property(t => t.PublishedToKb).HasColumnName("PublishedToKb");
            this.Property(t => t.Version).HasColumnName("Version");
        }
    }
}
