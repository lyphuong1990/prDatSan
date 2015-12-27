namespace projectDatSan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("account")]
    public partial class account
    {
        public int id { get; set; }

        [Required]
        [StringLength(40)]
        public string username { get; set; }

        [Required]
        [StringLength(32)]
        public string password { get; set; }

        public bool? active { get; set; }

        public int? role { get; set; }

        public virtual role role1 { get; set; }
    }
}
