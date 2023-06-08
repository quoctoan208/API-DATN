namespace APIDATN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_DONHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_DONHANG()
        {
            tbl_CHITIETDONHANG = new HashSet<tbl_CHITIETDONHANG>();
        }

        [StringLength(200)]
        public string diaChiGiaoHang { get; set; }

        [StringLength(50)]
        public string phuongThucThanhToan { get; set; }

        public double tongTienThanhToan { get; set; }

        public int? trangThaiDH { get; set; }

        public int? maSVMua { get; set; }

        public int? maSVBan { get; set; }

        [Key]
        [StringLength(15)]
        public string maDH { get; set; }

        public int? SDT { get; set; }

        [StringLength(50)]
        public string hoVaTen { get; set; }

        [StringLength(50)]
        public string ghiChu { get; set; }

        [StringLength(20)]
        public string ngayGiaoDich { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CHITIETDONHANG> tbl_CHITIETDONHANG { get; set; }
    }
}
