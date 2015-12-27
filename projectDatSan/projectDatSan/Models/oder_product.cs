namespace projectDatSan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class oder_product
    {
        public int id { get; set; }

        [StringLength(10)]
        public string name { get; set; }

        public int? customer_id { get; set; }

        public int? product_id { get; set; }

        public DateTime? time { get; set; }

        [StringLength(250)]
        public string name_order { get; set; }

        [StringLength(250)]
        public string email { get; set; }

        [StringLength(50)]
        public string phone { get; set; }

        [StringLength(250)]
        public string address { get; set; }

        public int? type_payment_id { get; set; }

        public bool? status { get; set; }

        public int? status_payment { get; set; }

        public virtual customer customer { get; set; }

        public virtual product product { get; set; }

        public virtual type_payment type_payment { get; set; }
    }
}
