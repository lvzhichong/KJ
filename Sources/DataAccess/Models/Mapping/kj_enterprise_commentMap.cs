using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class kj_enterprise_commentMap : EntityTypeConfiguration<kj_enterprise_comment>
    {
        public kj_enterprise_commentMap()
        {
            // Primary Key
            this.HasKey(t => t.comment_id);

            // Properties
            this.Property(t => t.comment_intro)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("kj_enterprise_comment");
            this.Property(t => t.comment_id).HasColumnName("comment_id");
            this.Property(t => t.user_id).HasColumnName("user_id");
            this.Property(t => t.enterprise_id).HasColumnName("enterprise_id");
            this.Property(t => t.comment_good).HasColumnName("comment_good");
            this.Property(t => t.comment_middle).HasColumnName("comment_middle");
            this.Property(t => t.comment_ugly).HasColumnName("comment_ugly");
            this.Property(t => t.comment_intro).HasColumnName("comment_intro");
            this.Property(t => t.comment_date).HasColumnName("comment_date");
        }
    }
}
