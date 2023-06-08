using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using APIDATN.Models;

namespace APIDATN.Controllers.APIClients
{
    public class TAIKHOANController : Controller
    {
        private Model1 db = new Model1();

        // GET: TAIKHOAN
        public ActionResult Index()
        {
            return View(db.tbl_TAIKHOAN.ToList());
        }

        // GET: TAIKHOAN/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_TAIKHOAN tbl_TAIKHOAN = db.tbl_TAIKHOAN.Find(id);
            if (tbl_TAIKHOAN == null)
            {
                return HttpNotFound();
            }
            return View(tbl_TAIKHOAN);
        }

        // GET: TAIKHOAN/Create
        public ActionResult Create()
        {
            return View();
        }

        

        // POST: TAIKHOAN/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maSV,sDT,matKhau,hoVaTen,diaChi,gioiTinh,maLop,danhGia")] tbl_TAIKHOAN tbl_TAIKHOAN)
        {
            if (ModelState.IsValid)
            {
                db.tbl_TAIKHOAN.Add(tbl_TAIKHOAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_TAIKHOAN);
        }

        // GET: TAIKHOAN/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_TAIKHOAN tbl_TAIKHOAN = db.tbl_TAIKHOAN.Find(id);
            if (tbl_TAIKHOAN == null)
            {
                return HttpNotFound();
            }
            return View(tbl_TAIKHOAN);
        }

        // POST: TAIKHOAN/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maSV,sDT,matKhau,hoVaTen,diaChi,gioiTinh,maLop,danhGia")] tbl_TAIKHOAN tbl_TAIKHOAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_TAIKHOAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_TAIKHOAN);
        }

        // GET: TAIKHOAN/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_TAIKHOAN tbl_TAIKHOAN = db.tbl_TAIKHOAN.Find(id);
            if (tbl_TAIKHOAN == null)
            {
                return HttpNotFound();
            }
            return View(tbl_TAIKHOAN);
        }

        // POST: TAIKHOAN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_TAIKHOAN tbl_TAIKHOAN = db.tbl_TAIKHOAN.Find(id);
            db.tbl_TAIKHOAN.Remove(tbl_TAIKHOAN);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
