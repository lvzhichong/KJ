using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class kj_project
    {
        public int project_id { get; set; }
        public Nullable<int> category_id { get; set; }
        public Nullable<int> user_id { get; set; }
        public string project_name { get; set; }
        public string project_anthor { get; set; }
        public string project_phone { get; set; }
        public Nullable<int> project_area { get; set; }
        public Nullable<int> project_public { get; set; }
        public Nullable<decimal> project_money { get; set; }
        public Nullable<System.DateTime> project_time { get; set; }
        public string project_files { get; set; }
        public string project_intro { get; set; }
        public Nullable<int> project_have { get; set; }
        public Nullable<int> project_publish { get; set; }
        public Nullable<int> project_person { get; set; }
        public Nullable<int> project_city { get; set; }
        public string project_aptitude { get; set; }
        public Nullable<System.DateTime> project_pubdate { get; set; }
        public Nullable<int> project_state { get; set; }
        public string project_filename { get; set; }
        public Nullable<System.DateTime> project_bid_date { get; set; }
        public Nullable<int> project_hours { get; set; }
    }
}
