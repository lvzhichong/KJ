using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class kj_project_bid_enterprise_albumMap : EntityTypeConfiguration<kj_project_bid_enterprise_album>
    {
        public kj_project_bid_enterprise_albumMap()
        {
            // Primary Key
            this.HasKey(t => t.p_album_id);

            // Properties
            this.Property(t => t.p_album_path)
                .HasMaxLength(300);

            this.Property(t => t.p_album_thumbpath)
                .HasMaxLength(300);

            // Table & Column Mappings
            this.ToTable("kj_project_bid_enterprise_album");
            this.Property(t => t.p_album_id).HasColumnName("p_album_id");
            this.Property(t => t.bid_id).HasColumnName("bid_id");
            this.Property(t => t.p_album_path).HasColumnName("p_album_path");
            this.Property(t => t.p_album_thumbpath).HasColumnName("p_album_thumbpath");
        }
    }
}
