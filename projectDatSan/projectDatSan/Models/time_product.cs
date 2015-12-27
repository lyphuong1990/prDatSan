namespace projectDatSan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class time_product
    {
        public int id { get; set; }

        public int? product_id { get; set; }

        public DateTime? start_time { get; set; }

        public DateTime? end_time { get; set; }

        public double? price { get; set; }

        public int? time_id { get; set; }

        public virtual product product { get; set; }

        public virtual time time { get; set; }
    }
}
