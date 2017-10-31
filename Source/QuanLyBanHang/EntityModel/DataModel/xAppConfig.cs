namespace EntityModel.DataModel
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("xAppConfig")]
    public partial class xAppConfig
    {
        [Key]
        public int KeyID { get; set; }
        [Required]
        [StringLength(255)]
        public string colName { get; set; }
        public int? colInt { get; set; }
        public decimal? colDecimal { get; set; }
        public double? colFloat { get; set; }
        public string colString { get; set; }
        public bool? colBit { get; set; }
        public DateTime? colDateTime { get; set; }
        [MaxLength(128)]
        public byte[] colBinary { get; set; }
        public string colXML { get; set; }
    }
}
