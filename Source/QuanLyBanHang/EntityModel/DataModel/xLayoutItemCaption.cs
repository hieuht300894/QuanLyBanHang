namespace EntityModel.DataModel
{
    using System.ComponentModel.DataAnnotations;

    public partial class xLayoutItemCaption
    {
        [Key]
        public int KeyID { get; set; }
        [Required]
        [StringLength(255)]
        public string FormName { get; set; }
        [Required]
        [StringLength(255)]
        public string LayoutControlName { get; set; }
        [Required]
        [StringLength(255)]
        public string LayoutControlItem { get; set; }
        [Required]
        [StringLength(255)]
        public string VN { get; set; }
        [Required]
        [StringLength(255)]
        public string EN { get; set; }
        [Required]
        [StringLength(255)]
        public string Visibility { get; set; }
        public bool TextVisible { get; set; }   
        [Required]
        [StringLength(255)]
        public string TextLocation { get; set; }
        [Required]
        [StringLength(255)]
        public string ControlAlignment { get; set; }
    }
}
