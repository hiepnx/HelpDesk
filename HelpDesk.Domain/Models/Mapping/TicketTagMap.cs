using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HelpDesk.Domain.Models.Mapping
{
    public class TicketTagMap : EntityTypeConfiguration<TicketTag>
    {
        public TicketTagMap()
        {
            // Primary Key
            this.HasKey(t => t.TicketTagId);

            // Properties
            this.Property(t => t.TagName)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("TicketTags");
            this.Property(t => t.TicketTagId).HasColumnName("TicketTagId");
            this.Property(t => t.TagName).HasColumnName("TagName");
            this.Property(t => t.TicketId).HasColumnName("TicketId");

            // Relationships
            this.HasRequired(t => t.Ticket)
                .WithMany(t => t.TicketTags)
                .HasForeignKey(d => d.TicketId);

        }
    }
}
