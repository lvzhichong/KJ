using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class kj_enterprise_comment
    {
        public int comment_id { get; set; }
        public Nullable<int> user_id { get; set; }
        public Nullable<int> enterprise_id { get; set; }
        public Nullable<int> comment_good { get; set; }
        public Nullable<int> comment_middle { get; set; }
        public Nullable<int> comment_ugly { get; set; }
        public string comment_intro { get; set; }
        public Nullable<System.DateTime> comment_date { get; set; }
    }
}
