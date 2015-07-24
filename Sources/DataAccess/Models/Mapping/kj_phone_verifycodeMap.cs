using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class kj_phone_verifycodeMap : EntityTypeConfiguration<kj_phone_verifycode>
    {
        public kj_phone_verifycodeMap()
        {
            // Primary Key
            this.HasKey(t => t.phone_id);

            // Properties
            this.Property(t => t.phone_num)
                .HasMaxLength(50);

            this.Property(t => t.phone_code)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("kj_phone_verifycode");
            this.Property(t => t.phone_id).HasColumnName("phone_id");
            this.Property(t => t.phone_num).HasColumnName("phone_num");
            this.Property(t => t.phone_code).HasColumnName("phone_code");
            this.Property(t => t.phone_state).HasColumnName("phone_state");
            this.Property(t => t.phone_overdate).HasColumnName("phone_overdate");
            this.Property(t => t.phone_createdate).HasColumnName("phone_createdate");
        }
    }
}
