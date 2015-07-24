using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class kj_serviceMap : EntityTypeConfiguration<kj_service>
    {
        public kj_serviceMap()
        {
            // Primary Key
            this.HasKey(t => t.service_id);

            // Properties
            this.Property(t => t.service_name)
                .HasMaxLength(300);

            this.Property(t => t.service_person)
                .HasMaxLength(50);

            this.Property(t => t.service_phone)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("kj_service");
            this.Property(t => t.service_id).HasColumnName("service_id");
            this.Property(t => t.user_id).HasColumnName("user_id");
            this.Property(t => t.enterpries_id).HasColumnName("enterpries_id");
            this.Property(t => t.service_name).HasColumnName("service_name");
            this.Property(t => t.service_person).HasColumnName("service_person");
            this.Property(t => t.service_phone).HasColumnName("service_phone");
        }
    }
}
