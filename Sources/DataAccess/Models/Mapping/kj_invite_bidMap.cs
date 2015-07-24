using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class kj_invite_bidMap : EntityTypeConfiguration<kj_invite_bid>
    {
        public kj_invite_bidMap()
        {
            // Primary Key
            this.HasKey(t => t.invite_id);

            // Properties
            this.Property(t => t.invite_enterprise)
                .HasMaxLength(300);

            // Table & Column Mappings
            this.ToTable("kj_invite_bid");
            this.Property(t => t.invite_id).HasColumnName("invite_id");
            this.Property(t => t.project_id).HasColumnName("project_id");
            this.Property(t => t.invite_enterprise).HasColumnName("invite_enterprise");
            this.Property(t => t.invite_date).HasColumnName("invite_date");
        }
    }
}
