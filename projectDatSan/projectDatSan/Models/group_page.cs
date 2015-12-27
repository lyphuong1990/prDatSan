namespace projectDatSan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class group_page
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public group_page()
        {
            group_role = new HashSet<group_role>();
            maping_page = new HashSet<maping_page>();
        }

        public int id { get; set; }

        [StringLength(50)]
        public string group_page_name { get; set; }

        public bool? active { get; set; }

        public int? create_user { get; set; }

        public int? edit_user { get; set; }

        [Column(TypeName = "date")]
        public DateTime? create_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? update_date { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<group_role> group_role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<maping_page> maping_page { get; set; }
    }
}
