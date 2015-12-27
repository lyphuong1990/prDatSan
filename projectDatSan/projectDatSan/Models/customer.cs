namespace projectDatSan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("customer")]
    public partial class customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public customer()
        {
            oder_product = new HashSet<oder_product>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(250)]
        public string full_name { get; set; }

        [StringLength(250)]
        public string name { get; set; }

        [StringLength(250)]
        public string password { get; set; }

        [StringLength(250)]
        public string email { get; set; }

        [StringLength(50)]
        public string phone { get; set; }

        [StringLength(250)]
        public string address { get; set; }

        public int? city_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<oder_product> oder_product { get; set; }
    }
}
