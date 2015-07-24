using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class kj_user_oauth_appMap : EntityTypeConfiguration<kj_user_oauth_app>
    {
        public kj_user_oauth_appMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.title)
                .HasMaxLength(200);

            this.Property(t => t.img_url)
                .HasMaxLength(300);

            this.Property(t => t.app_id)
                .HasMaxLength(200);

            this.Property(t => t.app_key)
                .HasMaxLength(200);

            this.Property(t => t.api_path)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("kj_user_oauth_app");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.title).HasColumnName("title");
            this.Property(t => t.img_url).HasColumnName("img_url");
            this.Property(t => t.app_id).HasColumnName("app_id");
            this.Property(t => t.app_key).HasColumnName("app_key");
            this.Property(t => t.remark).HasColumnName("remark");
            this.Property(t => t.sort_id).HasColumnName("sort_id");
            this.Property(t => t.is_lock).HasColumnName("is_lock");
            this.Property(t => t.api_path).HasColumnName("api_path");
        }
    }
}
