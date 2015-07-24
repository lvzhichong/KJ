using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class kj_project_album
    {
        public int album_id { get; set; }
        public Nullable<int> project_id { get; set; }
        public string album_path { get; set; }
        public string album_thumbpath { get; set; }
    }
}
