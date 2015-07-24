using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class kj_project_albumMap : EntityTypeConfiguration<kj_project_album>
    {
        public kj_project_albumMap()
        {
            // Primary Key
            this.HasKey(t => t.album_id);

            // Properties
            this.Property(t => t.album_path)
                .HasMaxLength(300);

            this.Property(t => t.album_thumbpath)
                .HasMaxLength(300);

            // Table & Column Mappings
            this.ToTable("kj_project_album");
            this.Property(t => t.album_id).HasColumnName("album_id");
            this.Property(t => t.project_id).HasColumnName("project_id");
            this.Property(t => t.album_path).HasColumnName("album_path");
            this.Property(t => t.album_thumbpath).HasColumnName("album_thumbpath");
        }
    }
}
