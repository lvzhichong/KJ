using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class kj_userMap : EntityTypeConfiguration<kj_user>
    {
        public kj_userMap()
        {
            // Primary Key
            this.HasKey(t => t.user_id);

            // Properties
            this.Property(t => t.user_name)
                .HasMaxLength(50);

            this.Property(t => t.user_pwd)
                .HasMaxLength(50);

            this.Property(t => t.user_regip)
                .HasMaxLength(20);

            this.Property(t => t.user_phone)
                .HasMaxLength(20);

            this.Property(t => t.user_email)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("kj_user");
            this.Property(t => t.user_id).HasColumnName("user_id");
            this.Property(t => t.user_name).HasColumnName("user_name");
            this.Property(t => t.user_pwd).HasColumnName("user_pwd");
            this.Property(t => t.user_regdate).HasColumnName("user_regdate");
            this.Property(t => t.user_regip).HasColumnName("user_regip");
            this.Property(t => t.user_lastlogindate).HasColumnName("user_lastlogindate");
            this.Property(t => t.user_money).HasColumnName("user_money");
            this.Property(t => t.user_phone).HasColumnName("user_phone");
            this.Property(t => t.user_email).HasColumnName("user_email");
            this.Property(t => t.user_attr).HasColumnName("user_attr");
        }
    }
}
