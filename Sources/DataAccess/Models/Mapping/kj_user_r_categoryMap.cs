using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class kj_user_r_categoryMap : EntityTypeConfiguration<kj_user_r_category>
    {
        public kj_user_r_categoryMap()
        {
            // Primary Key
            this.HasKey(t => new { t.user_id, t.category_group_id });

            // Properties
            this.Property(t => t.user_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.category_group_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("kj_user_r_category");
            this.Property(t => t.user_id).HasColumnName("user_id");
            this.Property(t => t.category_group_id).HasColumnName("category_group_id");
        }
    }
}
