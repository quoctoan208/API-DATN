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
    public class tbl_ANHSPController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/tbl_ANHSP
        public IQueryable<tbl_ANHSP> Gettbl_ANHSP()
        {
            return db.tbl_ANHSP;
        }

        // GET: api/tbl_ANHSP/5
        [ResponseType(typeof(tbl_ANHSP))]
        public IHttpActionResult Gettbl_ANHSP(string id)
        {
            tbl_ANHSP tbl_ANHSP = db.tbl_ANHSP.Find(id);
            if (tbl_ANHSP == null)
            {
                return NotFound();
            }

            return Ok(tbl_ANHSP);
        }

        // PUT: api/tbl_ANHSP/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_ANHSP(string id, tbl_ANHSP tbl_ANHSP)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_ANHSP.maSP)
            {
                return BadRequest();
            }

            db.Entry(tbl_ANHSP).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_ANHSPExists(id))
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

        // POST: api/tbl_ANHSP
        [ResponseType(typeof(tbl_ANHSP))]
        public IHttpActionResult Posttbl_ANHSP(tbl_ANHSP tbl_ANHSP)
        {
            var tbl_ANHSPs = db.tbl_ANHSP.Where(x => x.maSP != tbl_ANHSP.maSP);

            db.tbl_ANHSP.Add(tbl_ANHSP);
            db.SaveChanges();

            return Ok(tbl_ANHSP);

        }

        // DELETE: api/tbl_ANHSP/5
        [ResponseType(typeof(tbl_ANHSP))]
        public IHttpActionResult Deletetbl_ANHSP(string id)
        {
            tbl_ANHSP tbl_ANHSP = db.tbl_ANHSP.Find(id);
            if (tbl_ANHSP == null)
            {
                return NotFound();
            }

            db.tbl_ANHSP.Remove(tbl_ANHSP);
            db.SaveChanges();

            return Ok(tbl_ANHSP);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_ANHSPExists(string id)
        {
            return db.tbl_ANHSP.Count(e => e.maSP == id) > 0;
        }
    }
}