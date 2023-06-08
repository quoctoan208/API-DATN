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
    public class THELOAIController : Controller
    {
        private Model1 db = new Model1();

        // GET: THELOAI
        public ActionResult Index()
        {
            return View(db.tbl_THELOAI.ToList());
        }

        // GET: THELOAI/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_THELOAI tbl_THELOAI = db.tbl_THELOAI.Find(id);
            if (tbl_THELOAI == null)
            {
                return HttpNotFound();
            }
            return View(tbl_THELOAI);
        }

        // GET: THELOAI/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: THELOAI/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maTL,tenTL")] tbl_THELOAI tbl_THELOAI)
        {
            if (ModelState.IsValid)
            {
                db.tbl_THELOAI.Add(tbl_THELOAI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_THELOAI);
        }

        // GET: THELOAI/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_THELOAI tbl_THELOAI = db.tbl_THELOAI.Find(id);
            if (tbl_THELOAI == null)
            {
                return HttpNotFound();
            }
            return View(tbl_THELOAI);
        }

        // POST: THELOAI/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maTL,tenTL")] tbl_THELOAI tbl_THELOAI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_THELOAI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_THELOAI);
        }

        // GET: THELOAI/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_THELOAI tbl_THELOAI = db.tbl_THELOAI.Find(id);
            if (tbl_THELOAI == null)
            {
                return HttpNotFound();
            }
            return View(tbl_THELOAI);
        }

        // POST: THELOAI/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbl_THELOAI tbl_THELOAI = db.tbl_THELOAI.Find(id);
            db.tbl_THELOAI.Remove(tbl_THELOAI);
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
