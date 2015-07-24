using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class kj_answer
    {
        public int answer_id { get; set; }
        public Nullable<int> question_id { get; set; }
        public Nullable<int> user_id { get; set; }
        public string answer_name { get; set; }
        public string answer_intro { get; set; }
        public Nullable<System.DateTime> answer_time { get; set; }
        public string answer_ip { get; set; }
        public string answer_user { get; set; }
        public Nullable<int> answer_lock { get; set; }
        public Nullable<int> answer_parent { get; set; }
        public Nullable<int> answer_up { get; set; }
        public Nullable<int> answer_down { get; set; }
    }
}
