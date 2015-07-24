using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DataAccess.Models
{
    public partial class kj_category
    {
        [NotMapped]
        public int project_count { get; set; }
    }
}
