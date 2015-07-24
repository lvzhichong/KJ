using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class kj_enterprise_channel_typeMap : EntityTypeConfiguration<kj_enterprise_channel_type>
    {
        public kj_enterprise_channel_typeMap()
        {
            // Primary Key
            this.HasKey(t => t.channel_type_id);

            // Properties
            this.Property(t => t.channel_type_name)
                .HasMaxLength(100);

            this.Property(t => t.channel_type_intro)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("kj_enterprise_channel_type");
            this.Property(t => t.channel_type_id).HasColumnName("channel_type_id");
            this.Property(t => t.channel_id).HasColumnName("channel_id");
            this.Property(t => t.channel_type_name).HasColumnName("channel_type_name");
            this.Property(t => t.channel_type_intro).HasColumnName("channel_type_intro");
        }
    }
}
