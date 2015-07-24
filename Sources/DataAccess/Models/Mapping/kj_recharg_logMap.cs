using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class kj_recharg_logMap : EntityTypeConfiguration<kj_recharg_log>
    {
        public kj_recharg_logMap()
        {
            // Primary Key
            this.HasKey(t => t.recharg_id);

            // Properties
            // Table & Column Mappings
            this.ToTable("kj_recharg_log");
            this.Property(t => t.recharg_id).HasColumnName("recharg_id");
            this.Property(t => t.user_id).HasColumnName("user_id");
            this.Property(t => t.recharg_money).HasColumnName("recharg_money");
            this.Property(t => t.recharg_date).HasColumnName("recharg_date");
            this.Property(t => t.recharg_mode).HasColumnName("recharg_mode");
        }
    }
}
