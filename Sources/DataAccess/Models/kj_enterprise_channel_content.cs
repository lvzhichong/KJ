using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class kj_enterprise_channel_content
    {
        public int content_id { get; set; }
        public Nullable<int> channel_id { get; set; }
        public string content_name { get; set; }
        public string content_intro { get; set; }
        public string content_files { get; set; }
        public Nullable<int> channel_type_id { get; set; }
        public Nullable<int> user_id { get; set; }
    }
}
