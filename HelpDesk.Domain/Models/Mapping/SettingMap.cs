using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HelpDesk.Domain.Models.Mapping
{
    public class SettingMap : EntityTypeConfiguration<Setting>
    {
        public SettingMap()
        {
            // Primary Key
            this.HasKey(t => t.SettingName);

            // Properties
            this.Property(t => t.SettingName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.SettingType)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Settings");
            this.Property(t => t.SettingName).HasColumnName("SettingName");
            this.Property(t => t.SettingValue).HasColumnName("SettingValue");
            this.Property(t => t.DefaultValue).HasColumnName("DefaultValue");
            this.Property(t => t.SettingType).HasColumnName("SettingType");
            this.Property(t => t.SettingDescription).HasColumnName("SettingDescription");
        }
    }
}
