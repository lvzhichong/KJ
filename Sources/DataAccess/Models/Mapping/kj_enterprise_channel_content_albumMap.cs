using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class kj_enterprise_channel_content_albumMap : EntityTypeConfiguration<kj_enterprise_channel_content_album>
    {
        public kj_enterprise_channel_content_albumMap()
        {
            // Primary Key
            this.HasKey(t => t.content_album_id);

            // Properties
            this.Property(t => t.content_album_path)
                .HasMaxLength(300);

            this.Property(t => t.content_album_thumbpath)
                .HasMaxLength(300);

            this.Property(t => t.content_album_name)
                .HasMaxLength(255);

            this.Property(t => t.content_album_intro)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("kj_enterprise_channel_content_album");
            this.Property(t => t.content_album_id).HasColumnName("content_album_id");
            this.Property(t => t.content_id).HasColumnName("content_id");
            this.Property(t => t.content_album_path).HasColumnName("content_album_path");
            this.Property(t => t.content_album_thumbpath).HasColumnName("content_album_thumbpath");
            this.Property(t => t.content_album_name).HasColumnName("content_album_name");
            this.Property(t => t.content_album_intro).HasColumnName("content_album_intro");
        }
    }
}
