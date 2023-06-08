using APIDATN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APIDATN.Controllers
{

    public class HomeController : Controller
    {
        Model1 db = new Model1();
        public ActionResult Index()
        {
            int userCount = db.tbl_TAIKHOAN.ToList().Count;
            int SanPham = db.tbl_SANPHAM.ToList().Count;
            int Theloai = db.tbl_THELOAI.ToList().Count;
            int DonHang = db.tbl_DONHANG.ToList().Count;
            ViewBag.SanPham = SanPham;
            ViewBag.userCount = userCount;
            ViewBag.TheLoai = Theloai;
            ViewBag.DonHang = DonHang;

            return View();
        }



        public ActionResult Dangnhap()
        {
            return View();
        }
    }
}
