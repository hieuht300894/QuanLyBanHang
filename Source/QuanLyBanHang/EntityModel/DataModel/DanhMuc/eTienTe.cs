﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModel.DataModel.DanhMuc
{
    [Table("eTienTe")]
    public class eTienTe
    {
        [Key]
        public int KeyID { get; set; }
    }
}
