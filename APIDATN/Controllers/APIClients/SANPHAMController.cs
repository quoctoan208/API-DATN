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
    public class SANPHAMController : Controller
    {
        private Model1 db = new Model1();

        // GET: SANPHAM
        public ActionResult Index()
        {
            var tbl_SANPHAM = db.tbl_SANPHAM.Include(t => t.tbl_THELOAI);
            ViewBag.maTL = db.tbl_THELOAI.ToList();
            return View(tbl_SANPHAM.ToList());
        }

        public ActionResult XetDuyet(string maSP)
        {
            tbl_SANPHAM sanpham = db.tbl_SANPHAM.Find(maSP);
            int a = 2;
            sanpham.xetDuyet = a;
            db.Entry(sanpham).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult HuyDuyet(string maSP)
        {
            tbl_SANPHAM sanpham = db.tbl_SANPHAM.Find(maSP);
            int a = 1;
            sanpham.xetDuyet = 1;
            db.Entry(sanpham).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: SANPHAM/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_SANPHAM tbl_SANPHAM = db.tbl_SANPHAM.Find(id);
            if (tbl_SANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(tbl_SANPHAM);
        }

        // GET: SANPHAM/Create
        public ActionResult Create()
        {
            ViewBag.maTL = new SelectList(db.tbl_THELOAI, "maTL", "tenTL");
            return View();
        }

        // POST: SANPHAM/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maSP,maTL,tenSP,anhSP,donGia,soLuong,matoSP,xetDuyet,maSV")] tbl_SANPHAM tbl_SANPHAM)
        {
            if (ModelState.IsValid)
            {
                db.tbl_SANPHAM.Add(tbl_SANPHAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maTL = new SelectList(db.tbl_THELOAI, "maTL", "tenTL", tbl_SANPHAM.maTL);
            return View(tbl_SANPHAM);
        }

        // GET: SANPHAM/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_SANPHAM tbl_SANPHAM = db.tbl_SANPHAM.Find(id);
            if (tbl_SANPHAM == null)
            {
                return HttpNotFound();
            }
            ViewBag.maTL = new SelectList(db.tbl_THELOAI, "maTL", "tenTL", tbl_SANPHAM.maTL);
            return View(tbl_SANPHAM);
        }

        // POST: SANPHAM/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maSP,maTL,tenSP,anhSP,donGia,soLuong,matoSP,xetDuyet,maSV")] tbl_SANPHAM tbl_SANPHAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_SANPHAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maTL = new SelectList(db.tbl_THELOAI, "maTL", "tenTL", tbl_SANPHAM.maTL);
            return View(tbl_SANPHAM);
        }

        // GET: SANPHAM/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_SANPHAM tbl_SANPHAM = db.tbl_SANPHAM.Find(id);
            if (tbl_SANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(tbl_SANPHAM);
        }

        // POST: SANPHAM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbl_SANPHAM tbl_SANPHAM = db.tbl_SANPHAM.Find(id);
            db.tbl_SANPHAM.Remove(tbl_SANPHAM);
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
