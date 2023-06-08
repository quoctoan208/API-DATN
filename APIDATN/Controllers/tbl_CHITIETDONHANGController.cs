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
    public class tbl_CHITIETDONHANGController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/tbl_CHITIETDONHANG
        public IQueryable<tbl_CHITIETDONHANG> Gettbl_CHITIETDONHANG()
        {
            return db.tbl_CHITIETDONHANG;
        }

        // GET: api/tbl_CHITIETDONHANG/5
        [ResponseType(typeof(tbl_CHITIETDONHANG))]
        public IHttpActionResult Gettbl_CHITIETDONHANG(string id)
        {
            tbl_CHITIETDONHANG tbl_CHITIETDONHANG = db.tbl_CHITIETDONHANG.Find(id);
            if (tbl_CHITIETDONHANG == null)
            {
                return NotFound();
            }

            return Ok(tbl_CHITIETDONHANG);
        }

        [HttpGet]
        [Route("api/tbl_CHITIETDONHANG/getChiTietDonHangbyDH/{maDH}")]
        public IHttpActionResult getChiTietDonHangbyDH(string maDH)
        {
            var check = db.tbl_CHITIETDONHANG.Where(x => x.maDH == maDH).ToList();
            if (check == null && check.Count == 0)
            {
                return NotFound();
            }

            return Ok(check);
        }

        // PUT: api/tbl_CHITIETDONHANG/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_CHITIETDONHANG(string id, tbl_CHITIETDONHANG tbl_CHITIETDONHANG)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_CHITIETDONHANG.id)
            {
                return BadRequest();
            }

            db.Entry(tbl_CHITIETDONHANG).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_CHITIETDONHANGExists(id))
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

        // POST: api/tbl_CHITIETDONHANG
        [ResponseType(typeof(tbl_CHITIETDONHANG))]
        public IHttpActionResult Posttbl_CHITIETDONHANG(tbl_CHITIETDONHANG tbl_CHITIETDONHANG)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_CHITIETDONHANG.Add(tbl_CHITIETDONHANG);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tbl_CHITIETDONHANGExists(tbl_CHITIETDONHANG.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tbl_CHITIETDONHANG.id }, tbl_CHITIETDONHANG);
        }

        // DELETE: api/tbl_CHITIETDONHANG/5
        [ResponseType(typeof(tbl_CHITIETDONHANG))]
        public IHttpActionResult Deletetbl_CHITIETDONHANG(string id)
        {
            tbl_CHITIETDONHANG tbl_CHITIETDONHANG = db.tbl_CHITIETDONHANG.Find(id);
            if (tbl_CHITIETDONHANG == null)
            {
                return NotFound();
            }

            db.tbl_CHITIETDONHANG.Remove(tbl_CHITIETDONHANG);
            db.SaveChanges();

            return Ok(tbl_CHITIETDONHANG);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_CHITIETDONHANGExists(string id)
        {
            return db.tbl_CHITIETDONHANG.Count(e => e.id == id) > 0;
        }
    }
}