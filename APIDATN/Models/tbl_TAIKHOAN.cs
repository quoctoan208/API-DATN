namespace APIDATN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_TAIKHOAN
    {
        public int? sDT { get; set; }

        [Required]
        [StringLength(15)]
        public string matKhau { get; set; }

        [StringLength(50)]
        public string hoVaTen { get; set; }

        [StringLength(200)]
        public string diaChi { get; set; }

        [StringLength(15)]
        public string gioiTinh { get; set; }

        public int? maLop { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int maSV { get; set; }

        public double? danhGia { get; set; }
    }
}
