namespace projectDatSan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("message")]
    public partial class message
    {
        public int id { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(500)]
        public string descript { get; set; }
    }
}
