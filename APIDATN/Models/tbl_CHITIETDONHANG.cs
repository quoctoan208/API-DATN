namespace APIDATN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_CHITIETDONHANG
    {
        [StringLength(10)]
        public string id { get; set; }

        public int? soLuongSP { get; set; }

        public double? tongTienThanhToan { get; set; }

        [StringLength(20)]
        public string maSP { get; set; }

        [Required]
        [StringLength(15)]
        public string maDH { get; set; }

        public virtual tbl_DONHANG tbl_DONHANG { get; set; }

        public virtual tbl_SANPHAM tbl_SANPHAM { get; set; }
    }
}
