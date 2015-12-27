namespace projectDatSan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class news
    {
        public int id { get; set; }

        [StringLength(250)]
        public string name { get; set; }

        [StringLength(2000)]
        public string description { get; set; }

        public int? type { get; set; }

        public DateTime? create_date { get; set; }

        public DateTime? update_date { get; set; }

        public int? create_user { get; set; }
    }
}
