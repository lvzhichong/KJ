using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class kj_answerMap : EntityTypeConfiguration<kj_answer>
    {
        public kj_answerMap()
        {
            // Primary Key
            this.HasKey(t => t.answer_id);

            // Properties
            this.Property(t => t.answer_name)
                .HasMaxLength(200);

            this.Property(t => t.answer_ip)
                .HasMaxLength(20);

            this.Property(t => t.answer_user)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("kj_answer");
            this.Property(t => t.answer_id).HasColumnName("answer_id");
            this.Property(t => t.question_id).HasColumnName("question_id");
            this.Property(t => t.user_id).HasColumnName("user_id");
            this.Property(t => t.answer_name).HasColumnName("answer_name");
            this.Property(t => t.answer_intro).HasColumnName("answer_intro");
            this.Property(t => t.answer_time).HasColumnName("answer_time");
            this.Property(t => t.answer_ip).HasColumnName("answer_ip");
            this.Property(t => t.answer_user).HasColumnName("answer_user");
            this.Property(t => t.answer_lock).HasColumnName("answer_lock");
            this.Property(t => t.answer_parent).HasColumnName("answer_parent");
            this.Property(t => t.answer_up).HasColumnName("answer_up");
            this.Property(t => t.answer_down).HasColumnName("answer_down");
        }
    }
}
