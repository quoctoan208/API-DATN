using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace APIDATN.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=DBContext")
        {
        }

        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tbl_ANHSP> tbl_ANHSP { get; set; }
        public virtual DbSet<tbl_CHITIETDONHANG> tbl_CHITIETDONHANG { get; set; }
        public virtual DbSet<tbl_DONHANG> tbl_DONHANG { get; set; }
        public virtual DbSet<tbl_GIOHANG> tbl_GIOHANG { get; set; }
        public virtual DbSet<tbl_SANPHAM> tbl_SANPHAM { get; set; }
        public virtual DbSet<tbl_TAIKHOAN> tbl_TAIKHOAN { get; set; }
        public virtual DbSet<tbl_THELOAI> tbl_THELOAI { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_ANHSP>()
                .Property(e => e.maSP)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_ANHSP>()
                .Property(e => e.anh1)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_ANHSP>()
                .Property(e => e.anh2)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_ANHSP>()
                .Property(e => e.anh3)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_ANHSP>()
                .Property(e => e.anh4)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_ANHSP>()
                .Property(e => e.anh5)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_CHITIETDONHANG>()
                .Property(e => e.id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tbl_CHITIETDONHANG>()
                .Property(e => e.maSP)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_CHITIETDONHANG>()
                .Property(e => e.maDH)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_DONHANG>()
                .Property(e => e.maDH)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_DONHANG>()
                .Property(e => e.ngayGiaoDich)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_DONHANG>()
                .HasMany(e => e.tbl_CHITIETDONHANG)
                .WithRequired(e => e.tbl_DONHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_GIOHANG>()
                .Property(e => e.maSP)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_SANPHAM>()
                .Property(e => e.maSP)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_SANPHAM>()
                .Property(e => e.maTL)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_SANPHAM>()
                .Property(e => e.anhSP)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_TAIKHOAN>()
                .Property(e => e.matKhau)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_THELOAI>()
                .Property(e => e.maTL)
                .IsUnicode(false);
        }
    }
}
