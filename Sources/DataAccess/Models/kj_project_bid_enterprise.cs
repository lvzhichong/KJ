using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class kj_project_bid_enterprise
    {
        public int bid_id { get; set; }
        public Nullable<int> project_id { get; set; }
        public Nullable<int> user_id { get; set; }
        public Nullable<decimal> bid_money { get; set; }
        public string bid_intro { get; set; }
        public string bid_files { get; set; }
        public string bid_plan_intro { get; set; }
        public Nullable<int> bid_state { get; set; }
        public Nullable<System.DateTime> bid_date { get; set; }
        public string bid_user { get; set; }
        public string bid_phone { get; set; }
        public string bid_email { get; set; }
        public Nullable<int> is_view { get; set; }
        public Nullable<int> bid_invite { get; set; }
    }
}
