using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class kj_projectMap : EntityTypeConfiguration<kj_project>
    {
        public kj_projectMap()
        {
            // Primary Key
            this.HasKey(t => t.project_id);

            // Properties
            this.Property(t => t.project_name)
                .HasMaxLength(200);

            this.Property(t => t.project_anthor)
                .HasMaxLength(30);

            this.Property(t => t.project_phone)
                .HasMaxLength(20);

            this.Property(t => t.project_files)
                .HasMaxLength(300);

            this.Property(t => t.project_aptitude)
                .HasMaxLength(300);

            this.Property(t => t.project_filename)
                .HasMaxLength(300);

            // Table & Column Mappings
            this.ToTable("kj_project");
            this.Property(t => t.project_id).HasColumnName("project_id");
            this.Property(t => t.category_id).HasColumnName("category_id");
            this.Property(t => t.user_id).HasColumnName("user_id");
            this.Property(t => t.project_name).HasColumnName("project_name");
            this.Property(t => t.project_anthor).HasColumnName("project_anthor");
            this.Property(t => t.project_phone).HasColumnName("project_phone");
            this.Property(t => t.project_area).HasColumnName("project_area");
            this.Property(t => t.project_public).HasColumnName("project_public");
            this.Property(t => t.project_money).HasColumnName("project_money");
            this.Property(t => t.project_time).HasColumnName("project_time");
            this.Property(t => t.project_files).HasColumnName("project_files");
            this.Property(t => t.project_intro).HasColumnName("project_intro");
            this.Property(t => t.project_have).HasColumnName("project_have");
            this.Property(t => t.project_publish).HasColumnName("project_publish");
            this.Property(t => t.project_person).HasColumnName("project_person");
            this.Property(t => t.project_city).HasColumnName("project_city");
            this.Property(t => t.project_aptitude).HasColumnName("project_aptitude");
            this.Property(t => t.project_pubdate).HasColumnName("project_pubdate");
            this.Property(t => t.project_state).HasColumnName("project_state");
            this.Property(t => t.project_filename).HasColumnName("project_filename");
            this.Property(t => t.project_bid_date).HasColumnName("project_bid_date");
            this.Property(t => t.project_hours).HasColumnName("project_hours");
        }
    }
}
