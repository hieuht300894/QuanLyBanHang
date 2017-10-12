namespace EntityModel.DataModel
{
    using System.ComponentModel.DataAnnotations;

    public partial class xUserFeature
    {
        [Key]
        public int KeyID { get; set; }
        public int IDUserRole { get; set; }
        [StringLength(255)]
        public string IDFeature { get; set; }
        public bool IsAdd { get; set; }
        public bool IsEdit { get; set; }
        public bool IsDelete { get; set; }
        public bool IsPrintPreview { get; set; }
        public bool IsExportExcel { get; set; }
        public bool IsSave { get; set; }
        public bool IsEnable { get; set; }
    }
}
