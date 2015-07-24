using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class kj_enterprise_channelMap : EntityTypeConfiguration<kj_enterprise_channel>
    {
        public kj_enterprise_channelMap()
        {
            // Primary Key
            this.HasKey(t => t.channel_id);

            // Properties
            this.Property(t => t.channel_name)
                .HasMaxLength(50);

            this.Property(t => t.channel_code)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("kj_enterprise_channel");
            this.Property(t => t.channel_id).HasColumnName("channel_id");
            this.Property(t => t.enterprise_id).HasColumnName("enterprise_id");
            this.Property(t => t.channel_name).HasColumnName("channel_name");
            this.Property(t => t.channel_order).HasColumnName("channel_order");
            this.Property(t => t.channel_code).HasColumnName("channel_code");
            this.Property(t => t.channel_system).HasColumnName("channel_system");
            this.Property(t => t.channel_type).HasColumnName("channel_type");
        }
    }
}
