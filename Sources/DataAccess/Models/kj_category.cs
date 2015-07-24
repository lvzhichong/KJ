using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class kj_category
    {
        public int category_id { get; set; }
        public Nullable<int> category_group_id { get; set; }
        public string category_name { get; set; }
        public Nullable<int> category_layer { get; set; }
        public Nullable<int> category_parent { get; set; }
    }
}
