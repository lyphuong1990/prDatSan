namespace projectDatSan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("feedback")]
    public partial class feedback
    {
        public int id { get; set; }

        [StringLength(250)]
        public string title { get; set; }

        [StringLength(1000)]
        public string descript { get; set; }

        [StringLength(100)]
        public string full_name { get; set; }

        [StringLength(250)]
        public string address { get; set; }

        [StringLength(250)]
        public string email { get; set; }

        [StringLength(30)]
        public string phone { get; set; }
    }
}
