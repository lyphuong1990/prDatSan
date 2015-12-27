namespace projectDatSan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class feed_back_product
    {
        public int id { get; set; }

        public int? product_id { get; set; }

        [StringLength(100)]
        public string title { get; set; }

        [StringLength(500)]
        public string description { get; set; }
    }
}
