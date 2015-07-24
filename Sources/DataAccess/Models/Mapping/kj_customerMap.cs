using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class kj_customerMap : EntityTypeConfiguration<kj_customer>
    {
        public kj_customerMap()
        {
            // Primary Key
            this.HasKey(t => t.customer_id);

            // Properties
            this.Property(t => t.customer_bid_project)
                .HasMaxLength(300);

            this.Property(t => t.service_person)
                .HasMaxLength(50);

            this.Property(t => t.service_phone)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("kj_customer");
            this.Property(t => t.customer_id).HasColumnName("customer_id");
            this.Property(t => t.user_id).HasColumnName("user_id");
            this.Property(t => t.customer_bid_id).HasColumnName("customer_bid_id");
            this.Property(t => t.customer_bid_project).HasColumnName("customer_bid_project");
            this.Property(t => t.service_person).HasColumnName("service_person");
            this.Property(t => t.service_phone).HasColumnName("service_phone");
        }
    }
}
