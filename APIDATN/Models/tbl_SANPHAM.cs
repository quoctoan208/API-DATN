namespace APIDATN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_SANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_SANPHAM()
        {
            tbl_CHITIETDONHANG = new HashSet<tbl_CHITIETDONHANG>();
        }

        [Key]
        [StringLength(20)]
        public string maSP { get; set; }

        [StringLength(15)]
        public string maTL { get; set; }

        [Required]
        [StringLength(50)]
        public string tenSP { get; set; }

        public string anhSP { get; set; }

        public double? donGia { get; set; }

        public int? soLuong { get; set; }

        public string matoSP { get; set; }

        public int? xetDuyet { get; set; }

        public int? maSV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CHITIETDONHANG> tbl_CHITIETDONHANG { get; set; }

        public virtual tbl_THELOAI tbl_THELOAI { get; set; }
    }
}
