using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class kj_commentMap : EntityTypeConfiguration<kj_comment>
    {
        public kj_commentMap()
        {
            // Primary Key
            this.HasKey(t => t.comment_id);

            // Properties
            this.Property(t => t.comment_name)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("kj_comment");
            this.Property(t => t.comment_id).HasColumnName("comment_id");
            this.Property(t => t.comment_name).HasColumnName("comment_name");
            this.Property(t => t.comment_intro).HasColumnName("comment_intro");
            this.Property(t => t.comment_send).HasColumnName("comment_send");
            this.Property(t => t.comment_addressee).HasColumnName("comment_addressee");
            this.Property(t => t.comment_sys).HasColumnName("comment_sys");
            this.Property(t => t.comment_date).HasColumnName("comment_date");
            this.Property(t => t.comment_view).HasColumnName("comment_view");
            this.Property(t => t.comment_check).HasColumnName("comment_check");
        }
    }
}
