using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class kj_enterprise_channel
    {
        public int channel_id { get; set; }
        public Nullable<int> enterprise_id { get; set; }
        public string channel_name { get; set; }
        public Nullable<int> channel_order { get; set; }
        public string channel_code { get; set; }
        public Nullable<int> channel_system { get; set; }
        public Nullable<int> channel_type { get; set; }
    }
}
