using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class kj_comment
    {
        public int comment_id { get; set; }
        public string comment_name { get; set; }
        public string comment_intro { get; set; }
        public Nullable<int> comment_send { get; set; }
        public Nullable<int> comment_addressee { get; set; }
        public Nullable<int> comment_sys { get; set; }
        public Nullable<System.DateTime> comment_date { get; set; }
        public Nullable<int> comment_view { get; set; }
        public Nullable<int> comment_check { get; set; }
    }
}
