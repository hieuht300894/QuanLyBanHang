using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModel.DataModel
{
    [Table("eTienTe")]
    public class eTienTe
    {
        [Key]
        public int KeyID { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public string MaDienTu { get; set; }
        public string KyHieu { get; set; }
        public byte[] Logo { get; set; }
    }
}
