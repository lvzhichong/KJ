using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class kj_dictionary_data
    {
        public int data_id { get; set; }
        public Nullable<int> dictionary_id { get; set; }
        public string data_name { get; set; }
        public string data_value { get; set; }
        public string data_layer { get; set; }
        public Nullable<int> parent_data_id { get; set; }
    }
}
