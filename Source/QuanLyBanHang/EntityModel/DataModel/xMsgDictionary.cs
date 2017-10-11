namespace EntityModel.DataModel
{
    using System.ComponentModel.DataAnnotations;

    public partial class xMsgDictionary
    {
        [Key]
        public int KeyID { get; set; }
        [Required]
        [StringLength(255)]
        public string FormName { get; set; }
        [Required]
        [StringLength(255)]
        public string MsgName { get; set; }
        [Required]
        public string VN { get; set; }
        [Required]
        public string EN { get; set; }
    }
}
