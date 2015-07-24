using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class kj_questionMap : EntityTypeConfiguration<kj_question>
    {
        public kj_questionMap()
        {
            // Primary Key
            this.HasKey(t => t.question_id);

            // Properties
            this.Property(t => t.question_name)
                .HasMaxLength(200);

            this.Property(t => t.question_ip)
                .HasMaxLength(20);

            this.Property(t => t.question_user)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("kj_question");
            this.Property(t => t.question_id).HasColumnName("question_id");
            this.Property(t => t.user_id).HasColumnName("user_id");
            this.Property(t => t.question_name).HasColumnName("question_name");
            this.Property(t => t.question_intro).HasColumnName("question_intro");
            this.Property(t => t.question_time).HasColumnName("question_time");
            this.Property(t => t.question_ip).HasColumnName("question_ip");
            this.Property(t => t.question_user).HasColumnName("question_user");
            this.Property(t => t.question_lock).HasColumnName("question_lock");
            this.Property(t => t.qunestion_view).HasColumnName("qunestion_view");
        }
    }
}
