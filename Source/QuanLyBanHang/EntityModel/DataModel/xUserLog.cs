namespace EntityModel.DataModel
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class xUserLog
    {
        [Key]
        public int KeyID { get; set; }

        public int IDPersonnel { get; set; }

        public DateTime AccessDate { get; set; }

        public string State { get; set; }

        public string TableName { get; set; }

        public string NewValue { get; set; }
    }
}
