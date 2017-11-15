using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModel.DataModel.Ton
{
    [Table("eCongNoDauKy")]
    class eCongNoDauKy
    {
        [Key]
        public int KeyID { get; set; }
    }
}
