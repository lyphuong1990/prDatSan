namespace projectDatSan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class group_role
    {
        public int id { get; set; }

        public int? id_group { get; set; }

        public int? role_id { get; set; }

        public virtual group_page group_page { get; set; }

        public virtual role role { get; set; }
    }
}
