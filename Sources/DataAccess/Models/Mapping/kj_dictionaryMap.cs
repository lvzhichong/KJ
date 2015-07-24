using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class kj_dictionaryMap : EntityTypeConfiguration<kj_dictionary>
    {
        public kj_dictionaryMap()
        {
            // Primary Key
            this.HasKey(t => t.dictionary_id);

            // Properties
            this.Property(t => t.dictionary_name)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("kj_dictionary");
            this.Property(t => t.dictionary_id).HasColumnName("dictionary_id");
            this.Property(t => t.dictionary_name).HasColumnName("dictionary_name");
        }
    }
}
