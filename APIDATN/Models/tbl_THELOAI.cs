namespace APIDATN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_THELOAI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_THELOAI()
        {
            tbl_SANPHAM = new HashSet<tbl_SANPHAM>();
        }

        [Key]
        [StringLength(15)]
        public string maTL { get; set; }

        [Required]
        [StringLength(50)]
        public string tenTL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_SANPHAM> tbl_SANPHAM { get; set; }
    }
}
