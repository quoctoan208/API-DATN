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
    public class tbl_THELOAIController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/tbl_THELOAI
        public IQueryable<tbl_THELOAI> Gettbl_THELOAI()
        {
            return db.tbl_THELOAI;
        }

        // GET: api/tbl_THELOAI/5
        [ResponseType(typeof(tbl_THELOAI))]
        public IHttpActionResult Gettbl_THELOAI(string id)
        {
            tbl_THELOAI tbl_THELOAI = db.tbl_THELOAI.Find(id);
            if (tbl_THELOAI == null)
            {
                return NotFound();
            }

            return Ok(tbl_THELOAI);
        }

        // PUT: api/tbl_THELOAI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_THELOAI(string id, tbl_THELOAI tbl_THELOAI)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_THELOAI.maTL)
            {
                return BadRequest();
            }

            db.Entry(tbl_THELOAI).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_THELOAIExists(id))
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

        // POST: api/tbl_THELOAI
        [ResponseType(typeof(tbl_THELOAI))]
        public IHttpActionResult Posttbl_THELOAI(tbl_THELOAI tbl_THELOAI)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_THELOAI.Add(tbl_THELOAI);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tbl_THELOAIExists(tbl_THELOAI.maTL))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tbl_THELOAI.maTL }, tbl_THELOAI);
        }

        // DELETE: api/tbl_THELOAI/5
        [ResponseType(typeof(tbl_THELOAI))]
        public IHttpActionResult Deletetbl_THELOAI(string id)
        {
            tbl_THELOAI tbl_THELOAI = db.tbl_THELOAI.Find(id);
            if (tbl_THELOAI == null)
            {
                return NotFound();
            }

            db.tbl_THELOAI.Remove(tbl_THELOAI);
            db.SaveChanges();

            return Ok(tbl_THELOAI);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_THELOAIExists(string id)
        {
            return db.tbl_THELOAI.Count(e => e.maTL == id) > 0;
        }
    }
}