namespace APIDATN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_GIOHANG
    {
        [Key]
        public int IDGIOHANG { get; set; }

        public int? maSV { get; set; }

        [StringLength(15)]
        public string maSP { get; set; }

        public int? soLuong { get; set; }

        public int? tongTien { get; set; }
    }
}
