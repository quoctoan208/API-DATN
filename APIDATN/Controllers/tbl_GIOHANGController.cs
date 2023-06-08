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
    public class tbl_GIOHANGController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/tbl_GIOHANG
        public IQueryable<tbl_GIOHANG> Gettbl_GIOHANG()
        {
            return db.tbl_GIOHANG;
        }

        // GET: api/tbl_GIOHANG/5
        [ResponseType(typeof(tbl_GIOHANG))]
        public IHttpActionResult Gettbl_GIOHANG(int id)
        {
            tbl_GIOHANG tbl_GIOHANG = db.tbl_GIOHANG.Find(id);
            if (tbl_GIOHANG == null)
            {
                return NotFound();
            }

            return Ok(tbl_GIOHANG);
        }
        // API cho việc truy vấn danh sách giỏ hàng của sinh viên dựa trên mã số sinh viên
        [HttpGet]
        [Route("api/tbl_GIOHANG/Gettbl_GIOHANGbyMaSV/{maSV}")]
        public IHttpActionResult Gettbl_GIOHANGbyMaSV(int maSV)
        {
            // Tìm kiếm danh sách giỏ hàng của sinh viên dựa trên mã số sinh viên
            var gioHangList = db.tbl_GIOHANG.Where(g => g.maSV == maSV).ToList();

            // Nếu không tìm thấy giỏ hàng, trả về mã trạng thái HTTP 404
            if (gioHangList == null || gioHangList.Count == 0)
            {
                return NotFound();
            }

            // Nếu tìm thấy giỏ hàng, trả về mã trạng thái HTTP 200 và danh sách giỏ hàng
            return Ok(gioHangList);
        }

        [HttpGet]
        [Route("api/tbl_GIOHANG/Gettbl_GIOHANGbyMaSP/{maSV}/{maSP}")]
        public IHttpActionResult Gettbl_GIOHANGbyMaSP(int maSV,string maSP)
        {
            // Tìm kiếm danh sách giỏ hàng của sinh viên dựa trên mã số sinh viên
            var gioHang = db.tbl_GIOHANG.Where(g => g.maSP == maSP && g.maSV == maSV);

            // Nếu không tìm thấy giỏ hàng, trả về mã trạng thái HTTP 404
            if (gioHang == null)
            {
                return NotFound();
            }

            // Nếu tìm thấy giỏ hàng, trả về mã trạng thái HTTP 200 và danh sách giỏ hàng
            return Ok(gioHang);
        }


        // PUT: api/tbl_GIOHANG/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_GIOHANG(int id, tbl_GIOHANG tbl_GIOHANG)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_GIOHANG.IDGIOHANG)
            {
                return BadRequest();
            }

            db.Entry(tbl_GIOHANG).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_GIOHANGExists(id))
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

        // POST: api/tbl_GIOHANG
        [ResponseType(typeof(tbl_GIOHANG))]
        public IHttpActionResult Posttbl_GIOHANG(tbl_GIOHANG tbl_GIOHANG)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_GIOHANG.Add(tbl_GIOHANG);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_GIOHANG.IDGIOHANG }, tbl_GIOHANG);
        }

        // DELETE: api/tbl_GIOHANG/5
        [ResponseType(typeof(tbl_GIOHANG))]
        public IHttpActionResult Deletetbl_GIOHANG(int id)
        {
            tbl_GIOHANG tbl_GIOHANG = db.tbl_GIOHANG.Find(id);
            if (tbl_GIOHANG == null)
            {
                return NotFound();
            }

            db.tbl_GIOHANG.Remove(tbl_GIOHANG);
            db.SaveChanges();

            return Ok(tbl_GIOHANG);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_GIOHANGExists(int id)
        {
            return db.tbl_GIOHANG.Count(e => e.IDGIOHANG == id) > 0;
        }
    }
}