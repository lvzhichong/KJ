using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class kj_question
    {
        public int question_id { get; set; }
        public Nullable<int> user_id { get; set; }
        public string question_name { get; set; }
        public string question_intro { get; set; }
        public Nullable<System.DateTime> question_time { get; set; }
        public string question_ip { get; set; }
        public string question_user { get; set; }
        public Nullable<int> question_lock { get; set; }
        public Nullable<int> qunestion_view { get; set; }
    }
}
