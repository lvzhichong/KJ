using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class kj_enterprise_channel_contentMap : EntityTypeConfiguration<kj_enterprise_channel_content>
    {
        public kj_enterprise_channel_contentMap()
        {
            // Primary Key
            this.HasKey(t => t.content_id);

            // Properties
            this.Property(t => t.content_name)
                .HasMaxLength(300);

            this.Property(t => t.content_files)
                .HasMaxLength(300);

            // Table & Column Mappings
            this.ToTable("kj_enterprise_channel_content");
            this.Property(t => t.content_id).HasColumnName("content_id");
            this.Property(t => t.channel_id).HasColumnName("channel_id");
            this.Property(t => t.content_name).HasColumnName("content_name");
            this.Property(t => t.content_intro).HasColumnName("content_intro");
            this.Property(t => t.content_files).HasColumnName("content_files");
            this.Property(t => t.channel_type_id).HasColumnName("channel_type_id");
            this.Property(t => t.user_id).HasColumnName("user_id");
        }
    }
}
