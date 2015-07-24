using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class kj_recharg_log
    {
        public int recharg_id { get; set; }
        public Nullable<int> user_id { get; set; }
        public Nullable<decimal> recharg_money { get; set; }
        public Nullable<System.DateTime> recharg_date { get; set; }
        public Nullable<int> recharg_mode { get; set; }
    }
}
