using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModel.DataModel.DauKy
{
    [Table("eCongNoDauKy")]
    public class eCongNoDauKy
    {
        [Key]
        public int KeyID { get; set; }
    }
}
