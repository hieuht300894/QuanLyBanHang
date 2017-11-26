namespace EntityModel.DataModel
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("xFeature")]
    public partial class xFeature
    {
        [Key]
        [StringLength(255)]
        public string KeyID { get; set; }
        [StringLength(255)]
        public string IDGroup { get; set; }
        [Required]
        [StringLength(255)]
        public string VN { get; set; }
        [Required]
        [StringLength(255)]
        public string EN { get; set; }
        public bool IsAdd { get; set; }
        public bool IsEdit { get; set; }
        public bool IsDelete { get; set; }
        public bool IsPrintPreview { get; set; }
        public bool IsExportExcel { get; set; }
        public bool IsSave { get; set; }
        public bool IsEnable { get; set; }
        public int ItemCount { get; set; }
        public int Level { get; set; }
    }
}
