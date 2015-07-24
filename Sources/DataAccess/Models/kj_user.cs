using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class kj_user
    {
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string user_pwd { get; set; }
        public Nullable<System.DateTime> user_regdate { get; set; }
        public string user_regip { get; set; }
        public Nullable<System.DateTime> user_lastlogindate { get; set; }
        public Nullable<decimal> user_money { get; set; }
        public string user_phone { get; set; }
        public string user_email { get; set; }
        public Nullable<int> user_attr { get; set; }
    }
}
