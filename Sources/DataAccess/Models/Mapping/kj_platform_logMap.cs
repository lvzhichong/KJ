using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class kj_platform_logMap : EntityTypeConfiguration<kj_platform_log>
    {
        public kj_platform_logMap()
        {
            // Primary Key
            this.HasKey(t => t.platform_id);

            // Properties
            this.Property(t => t.platform)
                .HasMaxLength(255);

            this.Property(t => t.version)
                .HasMaxLength(255);

            this.Property(t => t.deviceid)
                .HasMaxLength(255);

            this.Property(t => t.channel)
                .HasMaxLength(255);

            this.Property(t => t.decivetoken)
                .HasMaxLength(255);

            this.Property(t => t.sessionid)
                .HasMaxLength(255);

            this.Property(t => t.method)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("kj_platform_log");
            this.Property(t => t.platform_id).HasColumnName("platform_id");
            this.Property(t => t.platform).HasColumnName("platform");
            this.Property(t => t.version).HasColumnName("version");
            this.Property(t => t.deviceid).HasColumnName("deviceid");
            this.Property(t => t.channel).HasColumnName("channel");
            this.Property(t => t.decivetoken).HasColumnName("decivetoken");
            this.Property(t => t.sessionid).HasColumnName("sessionid");
            this.Property(t => t.request_time).HasColumnName("request_time");
            this.Property(t => t.method).HasColumnName("method");
        }
    }
}
