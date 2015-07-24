using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class kj_enterprise_channel_content_album
    {
        public int content_album_id { get; set; }
        public Nullable<int> content_id { get; set; }
        public string content_album_path { get; set; }
        public string content_album_thumbpath { get; set; }
        public string content_album_name { get; set; }
        public string content_album_intro { get; set; }
    }
}
