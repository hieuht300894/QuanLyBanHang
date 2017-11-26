using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.DataModel
{
    [Table("xLog")]
    public class xLog
    {
        [Key]
        public int KeyID { get; set; }

        public int IDPersonnel { get; set; }

        public DateTime AccessDate { get; set; }

        public string State { get; set; }

        public string TableName { get; set; }

        public string OldValue { get; set; }

        public string NewValue { get; set; }
    }
}
