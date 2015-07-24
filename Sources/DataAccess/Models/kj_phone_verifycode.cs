using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class kj_phone_verifycode
    {
        public int phone_id { get; set; }
        public string phone_num { get; set; }
        public string phone_code { get; set; }
        public Nullable<int> phone_state { get; set; }
        public Nullable<System.DateTime> phone_overdate { get; set; }
        public Nullable<System.DateTime> phone_createdate { get; set; }
    }
}
