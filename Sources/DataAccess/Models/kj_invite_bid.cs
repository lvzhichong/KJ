using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class kj_invite_bid
    {
        public int invite_id { get; set; }
        public Nullable<int> project_id { get; set; }
        public string invite_enterprise { get; set; }
        public Nullable<System.DateTime> invite_date { get; set; }
    }
}
