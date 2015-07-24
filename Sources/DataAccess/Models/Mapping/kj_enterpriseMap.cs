using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class kj_enterpriseMap : EntityTypeConfiguration<kj_enterprise>
    {
        public kj_enterpriseMap()
        {
            // Primary Key
            this.HasKey(t => t.user_id);

            // Properties
            this.Property(t => t.enterprise_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.user_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.enterprise_name)
                .HasMaxLength(200);

            this.Property(t => t.enterprise_address)
                .HasMaxLength(300);

            this.Property(t => t.enterprise_licence)
                .HasMaxLength(300);

            this.Property(t => t.enterprise_legal)
                .HasMaxLength(50);

            this.Property(t => t.enterprise_capital)
                .HasMaxLength(50);

            this.Property(t => t.enterprise_email)
                .HasMaxLength(300);

            this.Property(t => t.enterprise_tel)
                .HasMaxLength(30);

            this.Property(t => t.enterprise_logo)
                .HasMaxLength(255);

            this.Property(t => t.enterprise_sitename)
                .HasMaxLength(255);

            this.Property(t => t.enterprise_adcard)
                .HasMaxLength(255);

            this.Property(t => t.enterprise_qrcode)
                .HasMaxLength(255);

            this.Property(t => t.enterprise_qq)
                .HasMaxLength(100);

            this.Property(t => t.enterprise_siteenname)
                .HasMaxLength(255);

            this.Property(t => t.enterprise_siteseokey)
                .HasMaxLength(255);

            this.Property(t => t.enterprise_sitedesc)
                .HasMaxLength(255);

            this.Property(t => t.enterprise_sitetitle)
                .HasMaxLength(255);

            this.Property(t => t.enterprise_shortname)
                .HasMaxLength(255);

            this.Property(t => t.enterprise_color)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("kj_enterprise");
            this.Property(t => t.enterprise_id).HasColumnName("enterprise_id");
            this.Property(t => t.user_id).HasColumnName("user_id");
            this.Property(t => t.category_id).HasColumnName("category_id");
            this.Property(t => t.enterprise_name).HasColumnName("enterprise_name");
            this.Property(t => t.enterprise_area).HasColumnName("enterprise_area");
            this.Property(t => t.enterprise_address).HasColumnName("enterprise_address");
            this.Property(t => t.enterprise_person).HasColumnName("enterprise_person");
            this.Property(t => t.enterprise_primary1).HasColumnName("enterprise_primary1");
            this.Property(t => t.enterprise_primary2).HasColumnName("enterprise_primary2");
            this.Property(t => t.enterprise_primary3).HasColumnName("enterprise_primary3");
            this.Property(t => t.enterprise_intro).HasColumnName("enterprise_intro");
            this.Property(t => t.enterprise_licence).HasColumnName("enterprise_licence");
            this.Property(t => t.enterprise_legal).HasColumnName("enterprise_legal");
            this.Property(t => t.enterprise_capital).HasColumnName("enterprise_capital");
            this.Property(t => t.enterprise_email).HasColumnName("enterprise_email");
            this.Property(t => t.enterprise_tel).HasColumnName("enterprise_tel");
            this.Property(t => t.enterprise_sex).HasColumnName("enterprise_sex");
            this.Property(t => t.enterprise_licence_check).HasColumnName("enterprise_licence_check");
            this.Property(t => t.enterprise_phone_check).HasColumnName("enterprise_phone_check");
            this.Property(t => t.enterprise_sys_recommend).HasColumnName("enterprise_sys_recommend");
            this.Property(t => t.enterprise_logo).HasColumnName("enterprise_logo");
            this.Property(t => t.enterprise_sitename).HasColumnName("enterprise_sitename");
            this.Property(t => t.enterprise_adcard).HasColumnName("enterprise_adcard");
            this.Property(t => t.enterprise_qrcode).HasColumnName("enterprise_qrcode");
            this.Property(t => t.enterprise_qq).HasColumnName("enterprise_qq");
            this.Property(t => t.enterprise_siteenname).HasColumnName("enterprise_siteenname");
            this.Property(t => t.enterprise_siteseokey).HasColumnName("enterprise_siteseokey");
            this.Property(t => t.enterprise_sitedesc).HasColumnName("enterprise_sitedesc");
            this.Property(t => t.enterprise_sitetitle).HasColumnName("enterprise_sitetitle");
            this.Property(t => t.enterprise_city).HasColumnName("enterprise_city");
            this.Property(t => t.enterprise_sys_identy).HasColumnName("enterprise_sys_identy");
            this.Property(t => t.enterprise_shortname).HasColumnName("enterprise_shortname");
            this.Property(t => t.enterprise_color).HasColumnName("enterprise_color");
            this.Property(t => t.enterprise_view).HasColumnName("enterprise_view");
        }
    }
}
