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
    public class tbl_DONHANGController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/tbl_DONHANG
        public IQueryable<tbl_DONHANG> Gettbl_DONHANG()
        {
            return db.tbl_DONHANG;
        }

        // GET: api/tbl_DONHANG/5
        [ResponseType(typeof(tbl_DONHANG))]
        public IHttpActionResult Gettbl_DONHANG(string id)
        {
            tbl_DONHANG tbl_DONHANG = db.tbl_DONHANG.Find(id);
            if (tbl_DONHANG == null)
            {
                return NotFound();
            }

            return Ok(tbl_DONHANG);
        }

        [HttpGet]
        [Route("api/tbl_DONHANG/Gettbl_DONHANGMUA/{maSVMua}/{trangThaiDH}")]
        public IHttpActionResult Gettbl_DONHANGMUA(int maSVMua, int trangThaiDH)
        {
            var check = db.tbl_DONHANG.Where(x => x.maSVMua == maSVMua && x.trangThaiDH == trangThaiDH).ToList();
            if (check == null || check.Count == 0)
            {
                return NotFound();
            }

            return Ok(check);
        }


        [HttpGet]
        [Route("api/tbl_DONHANG/Gettbl_DONHANGBAN/{maSVBan}/{trangThaiDH}")]
        public IHttpActionResult Gettbl_DONHANGBAN(int maSVBan, int trangThaiDH)
        {
            var check = db.tbl_DONHANG.Where(x => x.maSVBan == maSVBan && x.trangThaiDH == trangThaiDH).ToList();
            if (check == null || check.Count == 0)
            {
                return NotFound();
            }

            return Ok(check);
        }

        // PUT: api/tbl_DONHANG/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_DONHANG(string id, tbl_DONHANG tbl_DONHANG)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_DONHANG.maDH)
            {
                return BadRequest();
            }

            db.Entry(tbl_DONHANG).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_DONHANGExists(id))
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

        // POST: api/tbl_DONHANG
        [ResponseType(typeof(tbl_DONHANG))]
        public IHttpActionResult Posttbl_DONHANG(tbl_DONHANG tbl_DONHANG)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_DONHANG.Add(tbl_DONHANG);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tbl_DONHANGExists(tbl_DONHANG.maDH))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tbl_DONHANG.maDH }, tbl_DONHANG);
        }

        // DELETE: api/tbl_DONHANG/5
        [ResponseType(typeof(tbl_DONHANG))]
        public IHttpActionResult Deletetbl_DONHANG(string id)
        {
            tbl_DONHANG tbl_DONHANG = db.tbl_DONHANG.Find(id);
            if (tbl_DONHANG == null)
            {
                return NotFound();
            }

            db.tbl_DONHANG.Remove(tbl_DONHANG);
            db.SaveChanges();

            return Ok(tbl_DONHANG);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_DONHANGExists(string id)
        {
            return db.tbl_DONHANG.Count(e => e.maDH == id) > 0;
        }
    }
}