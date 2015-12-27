namespace projectDatSan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vote")]
    public partial class vote
    {
        public int id { get; set; }

        public int? product_id { get; set; }

        public int? vote_rate { get; set; }

        public virtual product product { get; set; }
    }
}
