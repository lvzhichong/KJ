using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using DataAccess.Models.Mapping;

namespace DataAccess.Models
{
    public partial class kj_dataContext : DbContext
    {
        static kj_dataContext()
        {
            Database.SetInitializer<kj_dataContext>(null);
        }

        public kj_dataContext()
            : base("Name=kj_dataContext")
        {
        }

        public DbSet<kj_answer> kj_answer { get; set; }
        public DbSet<kj_category> kj_category { get; set; }
        public DbSet<kj_category_group> kj_category_group { get; set; }
        public DbSet<kj_comment> kj_comment { get; set; }
        public DbSet<kj_customer> kj_customer { get; set; }
        public DbSet<kj_dictionary> kj_dictionary { get; set; }
        public DbSet<kj_dictionary_data> kj_dictionary_data { get; set; }
        public DbSet<kj_enterprise> kj_enterprise { get; set; }
        public DbSet<kj_enterprise_channel> kj_enterprise_channel { get; set; }
        public DbSet<kj_enterprise_channel_content> kj_enterprise_channel_content { get; set; }
        public DbSet<kj_enterprise_channel_content_album> kj_enterprise_channel_content_album { get; set; }
        public DbSet<kj_enterprise_channel_type> kj_enterprise_channel_type { get; set; }
        public DbSet<kj_enterprise_comment> kj_enterprise_comment { get; set; }
        public DbSet<kj_invite_bid> kj_invite_bid { get; set; }
        public DbSet<kj_phone_verifycode> kj_phone_verifycode { get; set; }
        public DbSet<kj_platform_log> kj_platform_log { get; set; }
        public DbSet<kj_project> kj_project { get; set; }
        public DbSet<kj_project_album> kj_project_album { get; set; }
        public DbSet<kj_project_bid_enterprise> kj_project_bid_enterprise { get; set; }
        public DbSet<kj_project_bid_enterprise_album> kj_project_bid_enterprise_album { get; set; }
        public DbSet<kj_question> kj_question { get; set; }
        public DbSet<kj_recharg_log> kj_recharg_log { get; set; }
        public DbSet<kj_service> kj_service { get; set; }
        public DbSet<kj_user> kj_user { get; set; }
        public DbSet<kj_user_oauth_app> kj_user_oauth_app { get; set; }
        public DbSet<kj_user_r_category> kj_user_r_category { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new kj_answerMap());
            modelBuilder.Configurations.Add(new kj_categoryMap());
            modelBuilder.Configurations.Add(new kj_category_groupMap());
            modelBuilder.Configurations.Add(new kj_commentMap());
            modelBuilder.Configurations.Add(new kj_customerMap());
            modelBuilder.Configurations.Add(new kj_dictionaryMap());
            modelBuilder.Configurations.Add(new kj_dictionary_dataMap());
            modelBuilder.Configurations.Add(new kj_enterpriseMap());
            modelBuilder.Configurations.Add(new kj_enterprise_channelMap());
            modelBuilder.Configurations.Add(new kj_enterprise_channel_contentMap());
            modelBuilder.Configurations.Add(new kj_enterprise_channel_content_albumMap());
            modelBuilder.Configurations.Add(new kj_enterprise_channel_typeMap());
            modelBuilder.Configurations.Add(new kj_enterprise_commentMap());
            modelBuilder.Configurations.Add(new kj_invite_bidMap());
            modelBuilder.Configurations.Add(new kj_phone_verifycodeMap());
            modelBuilder.Configurations.Add(new kj_platform_logMap());
            modelBuilder.Configurations.Add(new kj_projectMap());
            modelBuilder.Configurations.Add(new kj_project_albumMap());
            modelBuilder.Configurations.Add(new kj_project_bid_enterpriseMap());
            modelBuilder.Configurations.Add(new kj_project_bid_enterprise_albumMap());
            modelBuilder.Configurations.Add(new kj_questionMap());
            modelBuilder.Configurations.Add(new kj_recharg_logMap());
            modelBuilder.Configurations.Add(new kj_serviceMap());
            modelBuilder.Configurations.Add(new kj_userMap());
            modelBuilder.Configurations.Add(new kj_user_oauth_appMap());
            modelBuilder.Configurations.Add(new kj_user_r_categoryMap());
        }
    }
}
