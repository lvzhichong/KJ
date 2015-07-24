using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class kj_customer
    {
        public int customer_id { get; set; }
        public Nullable<int> user_id { get; set; }
        public Nullable<int> customer_bid_id { get; set; }
        public string customer_bid_project { get; set; }
        public string service_person { get; set; }
        public string service_phone { get; set; }
    }
}
