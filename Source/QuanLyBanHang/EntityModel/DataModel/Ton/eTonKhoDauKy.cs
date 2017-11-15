using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModel.DataModel.Ton
{
    [Table("eTonKhoDauKy")]
    public class eTonKhoDauKy
    {
        [Key]
        public int KeyID { get; set; }
    }
}
