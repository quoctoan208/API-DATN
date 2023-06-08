namespace APIDATN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_ANHSP
    {
        [Key]
        [StringLength(20)]
        public string maSP { get; set; }

        public string anh1 { get; set; }

        public string anh2 { get; set; }

        public string anh3 { get; set; }

        public string anh4 { get; set; }

        public string anh5 { get; set; }
    }
}
