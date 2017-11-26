using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModel.DataModel
{
    [Table("eQuyDoiDonVi")]
    public class eQuyDoiDonVi
    {
        [Key]
        public int KeyID { get; set; }
        public int IDDonViTinh { get; set; }
        public string DonViTinh { get; set; }
        public int IDDonViTinhQuyDoi { get; set; }
        public string DonViTinhQuyDoi { get; set; }
        public decimal GiaTri { get; set; }
    }
}
