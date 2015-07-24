using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class kj_project_bid_enterpriseMap : EntityTypeConfiguration<kj_project_bid_enterprise>
    {
        public kj_project_bid_enterpriseMap()
        {
            // Primary Key
            this.HasKey(t => t.bid_id);

            // Properties
            this.Property(t => t.bid_intro)
                .HasMaxLength(300);

            this.Property(t => t.bid_files)
                .HasMaxLength(300);

            this.Property(t => t.bid_user)
                .HasMaxLength(50);

            this.Property(t => t.bid_phone)
                .HasMaxLength(20);

            this.Property(t => t.bid_email)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("kj_project_bid_enterprise");
            this.Property(t => t.bid_id).HasColumnName("bid_id");
            this.Property(t => t.project_id).HasColumnName("project_id");
            this.Property(t => t.user_id).HasColumnName("user_id");
            this.Property(t => t.bid_money).HasColumnName("bid_money");
            this.Property(t => t.bid_intro).HasColumnName("bid_intro");
            this.Property(t => t.bid_files).HasColumnName("bid_files");
            this.Property(t => t.bid_plan_intro).HasColumnName("bid_plan_intro");
            this.Property(t => t.bid_state).HasColumnName("bid_state");
            this.Property(t => t.bid_date).HasColumnName("bid_date");
            this.Property(t => t.bid_user).HasColumnName("bid_user");
            this.Property(t => t.bid_phone).HasColumnName("bid_phone");
            this.Property(t => t.bid_email).HasColumnName("bid_email");
            this.Property(t => t.is_view).HasColumnName("is_view");
            this.Property(t => t.bid_invite).HasColumnName("bid_invite");
        }
    }
}
