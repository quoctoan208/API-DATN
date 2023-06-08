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
    public class tbl_SANPHAMController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/tbl_SANPHAM
        public IQueryable<tbl_SANPHAM> Gettbl_SANPHAM()
        {
            return db.tbl_SANPHAM;
        }

        // GET: api/tbl_SANPHAM/5
        [ResponseType(typeof(tbl_SANPHAM))]
        public IHttpActionResult Gettbl_SANPHAM(string id)
        {
            tbl_SANPHAM tbl_SANPHAM = db.tbl_SANPHAM.Find(id);
            if (tbl_SANPHAM == null)
            {
                return NotFound();
            }

            return Ok(tbl_SANPHAM);
        }

        [HttpGet]
        [Route("api/tbl_SANPHAM/TimKiemSP/{tenSP}")]
        public IHttpActionResult TimKiemSP(string tenSP)
        {
            var check = db.tbl_SANPHAM.Where(x => x.tenSP.Contains(tenSP));
            if (!check.Any())
            {
                return NotFound();
            }

            return Ok(check);
        }

        [HttpGet]
        [Route("api/tbl_SANPHAM/SPTL/{maTL}")]
        public IHttpActionResult SPTL(string maTL)
        {
            var check = db.tbl_SANPHAM.Where(x => x.maTL == maTL).ToList();
            if (check == null && check.Count == 0)
            {
                return NotFound();
            }

            return Ok(check);
        }


        // GET: api/tbl_SANPHAM/xetduyet
        [HttpGet]
        [Route("api/tbl_SANPHAM/Gettbl_SANPHAM_XETDUYET")]
        public IHttpActionResult Gettbl_SANPHAM_XETDUYET([FromUri(Name = "maSV")] int maSV, [FromUri(Name = "xetDuyet")] int xetDuyet)
        {
            var kiemtra = db.tbl_SANPHAM.Where(x => x.maSV != maSV && x.xetDuyet == xetDuyet).ToList();
            if (kiemtra == null || kiemtra.Count == 0)
            {
                return NotFound();
            }

            return Ok(kiemtra);
        }

        // sản phẩm của tôi
        [HttpGet]
        [Route("api/tbl_SANPHAM/Gettbl_SANPHAM_CUATOI")]
        public IHttpActionResult Gettbl_SANPHAM_CUATOI([FromUri(Name = "maSV")] int maSV)
        {
            var kiemtra = db.tbl_SANPHAM.Where(x => x.maSV == maSV ).ToList();
            if (kiemtra == null || kiemtra.Count == 0)
            {
                return NotFound();
            }

            return Ok(kiemtra);
        }

        // PUT: api/tbl_SANPHAM/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_SANPHAM(string id, tbl_SANPHAM tbl_SANPHAM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_SANPHAM.maSP)
            {
                return BadRequest();
            }

            db.Entry(tbl_SANPHAM).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_SANPHAMExists(id))
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

        // POST: api/tbl_SANPHAM
        [ResponseType(typeof(tbl_SANPHAM))]
        public IHttpActionResult Posttbl_SANPHAM(tbl_SANPHAM tbl_SANPHAM)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.tbl_SANPHAM.Add(tbl_SANPHAM);
            return Ok(db.SaveChanges());



            //var tbl_SANPHAMs = db.tbl_SANPHAM.Where(x => x.maSP != tbl_SANPHAM.maSP);

            //db.tbl_SANPHAM.Add(tbl_SANPHAM);
            //db.SaveChanges();

            //return Ok(tbl_SANPHAMs);

        }

        // DELETE: api/tbl_SANPHAM/5
        [ResponseType(typeof(tbl_SANPHAM))]
        public IHttpActionResult Deletetbl_SANPHAM(string id)
        {
            tbl_SANPHAM tbl_SANPHAM = db.tbl_SANPHAM.Find(id);
            if (tbl_SANPHAM == null)
            {
                return NotFound();
            }

            db.tbl_SANPHAM.Remove(tbl_SANPHAM);
            db.SaveChanges();

            return Ok(tbl_SANPHAM);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_SANPHAMExists(string id)
        {
            return db.tbl_SANPHAM.Count(e => e.maSP == id) > 0;
        }
    }
}