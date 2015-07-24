using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class kj_user_oauth_app
    {
        public int id { get; set; }
        public string title { get; set; }
        public string img_url { get; set; }
        public string app_id { get; set; }
        public string app_key { get; set; }
        public string remark { get; set; }
        public Nullable<int> sort_id { get; set; }
        public Nullable<int> is_lock { get; set; }
        public string api_path { get; set; }
    }
}
