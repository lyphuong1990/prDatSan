namespace projectDatSan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("product")]
    public partial class product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public product()
        {
            oder_product = new HashSet<oder_product>();
            time_product = new HashSet<time_product>();
            votes = new HashSet<vote>();
        }

        public int id { get; set; }

        [StringLength(250)]
        public string title { get; set; }

        [StringLength(250)]
        public string name { get; set; }

        [StringLength(2000)]
        public string description { get; set; }

        public int? province_id { get; set; }

        public double? vote_average { get; set; }

        public int? category_id { get; set; }

        public int? type_id { get; set; }

        public int? quantity { get; set; }

        public virtual category category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<oder_product> oder_product { get; set; }

        public virtual province province { get; set; }

        public virtual type type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<time_product> time_product { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vote> votes { get; set; }
    }
}
