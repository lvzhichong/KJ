using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class kj_enterprise_channel_type
    {
        public int channel_type_id { get; set; }
        public Nullable<int> channel_id { get; set; }
        public string channel_type_name { get; set; }
        public string channel_type_intro { get; set; }
    }
}
