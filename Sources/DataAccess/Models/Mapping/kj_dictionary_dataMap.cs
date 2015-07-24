using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class kj_dictionary_dataMap : EntityTypeConfiguration<kj_dictionary_data>
    {
        public kj_dictionary_dataMap()
        {
            // Primary Key
            this.HasKey(t => t.data_id);

            // Properties
            this.Property(t => t.data_name)
                .HasMaxLength(50);

            this.Property(t => t.data_value)
                .HasMaxLength(50);

            this.Property(t => t.data_layer)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("kj_dictionary_data");
            this.Property(t => t.data_id).HasColumnName("data_id");
            this.Property(t => t.dictionary_id).HasColumnName("dictionary_id");
            this.Property(t => t.data_name).HasColumnName("data_name");
            this.Property(t => t.data_value).HasColumnName("data_value");
            this.Property(t => t.data_layer).HasColumnName("data_layer");
            this.Property(t => t.parent_data_id).HasColumnName("parent_data_id");
        }
    }
}
