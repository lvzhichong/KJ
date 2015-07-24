using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public partial class kj_service
    {
        [NotMapped]
        public string enterprise_primary { get; set; }
    }
}
