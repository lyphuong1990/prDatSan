namespace projectDatSan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("citys")]
    public partial class city
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public city()
        {
            provinces = new HashSet<province>();
        }

        public int id { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        [StringLength(50)]
        public string latitude { get; set; }

        [StringLength(50)]
        public string longitude { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<province> provinces { get; set; }
    }
}
