namespace projectDatSan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class page
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public page()
        {
            maping_page = new HashSet<maping_page>();
        }

        public int id { get; set; }

        [StringLength(100)]
        public string page_name { get; set; }

        [StringLength(1000)]
        public string page_link { get; set; }

        public bool? active { get; set; }

        public int? id_action_page { get; set; }

        [StringLength(100)]
        public string sub_page_name { get; set; }

        [StringLength(1000)]
        public string subpage_link { get; set; }

        [StringLength(6)]
        public string control_string { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<maping_page> maping_page { get; set; }
    }
}
