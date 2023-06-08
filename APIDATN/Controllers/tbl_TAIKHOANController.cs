using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using APIDATN.Models;

namespace APIDATN.Controllers
{
    public class tbl_TAIKHOANController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/tbl_TAIKHOAN
        public IQueryable<tbl_TAIKHOAN> Gettbl_TAIKHOAN()
        {
            return db.tbl_TAIKHOAN;
        }

        // GET: api/tbl_TAIKHOAN/5
        [ResponseType(typeof(tbl_TAIKHOAN))]
        public IHttpActionResult Gettbl_TAIKHOAN(int id)
        {
            tbl_TAIKHOAN tbl_TAIKHOAN = db.tbl_TAIKHOAN.Find(id);
            if (tbl_TAIKHOAN == null)
            {
                return NotFound();
            }

            return Ok(tbl_TAIKHOAN);
        }


        [HttpGet]
        [Route("api/tbl_TAIKHOAN/getTaiKhoanbyMaSV/{maSV}")]
        public IHttpActionResult getTaiKhoanbyMaSV(int maSV)
        {
            var kiemtra = db.tbl_TAIKHOAN.Where(x => x.maSV == maSV);
            if (!kiemtra.Any())
            {
                return NotFound();
            }
            return Ok(kiemtra);
        }

        [HttpGet]
        [Route("api/tbl_TAIKHOAN/KiemTra/{masv}/{matkhau}")]
        public IHttpActionResult Kiemtra(int masv, string matkhau)
        {
            var kiemtra = db.tbl_TAIKHOAN.Where(x => x.maSV == masv && x.matKhau == matkhau);
            if (!kiemtra.Any())
            {
                return NotFound();
            }
            return Ok("ok");
        }


        // PUT: api/tbl_TAIKHOAN/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_TAIKHOAN(int id, tbl_TAIKHOAN tbl_TAIKHOAN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_TAIKHOAN.maSV)
            {
                return BadRequest();
            }

            db.Entry(tbl_TAIKHOAN).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_TAIKHOANExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/tbl_TAIKHOAN
        [ResponseType(typeof(tbl_TAIKHOAN))]
        public IHttpActionResult Posttbl_TAIKHOAN(tbl_TAIKHOAN tbl_TAIKHOAN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_TAIKHOAN.Add(tbl_TAIKHOAN);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tbl_TAIKHOANExists(tbl_TAIKHOAN.maSV))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tbl_TAIKHOAN.maSV }, tbl_TAIKHOAN);
        }

        // DELETE: api/tbl_TAIKHOAN/5
        [ResponseType(typeof(tbl_TAIKHOAN))]
        public IHttpActionResult Deletetbl_TAIKHOAN(int id)
        {
            tbl_TAIKHOAN tbl_TAIKHOAN = db.tbl_TAIKHOAN.Find(id);
            if (tbl_TAIKHOAN == null)
            {
                return NotFound();
            }

            db.tbl_TAIKHOAN.Remove(tbl_TAIKHOAN);
            db.SaveChanges();

            return Ok(tbl_TAIKHOAN);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_TAIKHOANExists(int id)
        {
            return db.tbl_TAIKHOAN.Count(e => e.maSV == id) > 0;
        }
    }
}