using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class kj_project_bid_enterprise_album
    {
        public int p_album_id { get; set; }
        public Nullable<int> bid_id { get; set; }
        public string p_album_path { get; set; }
        public string p_album_thumbpath { get; set; }
    }
}
