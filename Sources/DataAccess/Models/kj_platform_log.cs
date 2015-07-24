using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class kj_platform_log
    {
        public int platform_id { get; set; }
        public string platform { get; set; }
        public string version { get; set; }
        public string deviceid { get; set; }
        public string channel { get; set; }
        public string decivetoken { get; set; }
        public string sessionid { get; set; }
        public Nullable<System.DateTime> request_time { get; set; }
        public string method { get; set; }
    }
}
