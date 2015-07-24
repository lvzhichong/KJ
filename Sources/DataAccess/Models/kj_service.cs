using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class kj_service
    {
        public int service_id { get; set; }
        public Nullable<int> user_id { get; set; }
        public Nullable<int> enterpries_id { get; set; }
        public string service_name { get; set; }
        public string service_person { get; set; }
        public string service_phone { get; set; }
    }
}
