namespace projectDatSan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class maping_page
    {
        public int id { get; set; }

        public int? id_page { get; set; }

        public int? id_group { get; set; }

        [StringLength(6)]
        public string control_string { get; set; }

        public virtual group_page group_page { get; set; }

        public virtual page page { get; set; }
    }
}
