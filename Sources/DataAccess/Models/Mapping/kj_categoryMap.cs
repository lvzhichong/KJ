using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class kj_categoryMap : EntityTypeConfiguration<kj_category>
    {
        public kj_categoryMap()
        {
            // Primary Key
            this.HasKey(t => t.category_id);

            // Properties
            this.Property(t => t.category_name)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("kj_category");
            this.Property(t => t.category_id).HasColumnName("category_id");
            this.Property(t => t.category_group_id).HasColumnName("category_group_id");
            this.Property(t => t.category_name).HasColumnName("category_name");
            this.Property(t => t.category_layer).HasColumnName("category_layer");
            this.Property(t => t.category_parent).HasColumnName("category_parent");
        }
    }
}
