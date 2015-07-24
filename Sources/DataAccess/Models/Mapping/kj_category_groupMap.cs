using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class kj_category_groupMap : EntityTypeConfiguration<kj_category_group>
    {
        public kj_category_groupMap()
        {
            // Primary Key
            this.HasKey(t => t.category_group_id);

            // Properties
            this.Property(t => t.category_group_name)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("kj_category_group");
            this.Property(t => t.category_group_id).HasColumnName("category_group_id");
            this.Property(t => t.category_group_name).HasColumnName("category_group_name");
        }
    }
}
