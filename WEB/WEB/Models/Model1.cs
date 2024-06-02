using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WEB.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<BINHLUAN> BINHLUANs { get; set; }
        public virtual DbSet<CHITIETDONHANG> CHITIETDONHANGs { get; set; }
        public virtual DbSet<CHITIETGIAMGIA> CHITIETGIAMGIAs { get; set; }
        public virtual DbSet<CHITIETGIOHANG> CHITIETGIOHANGs { get; set; }
        public virtual DbSet<CUAHANG> CUAHANGs { get; set; }
        public virtual DbSet<DANHGIA> DANHGIAs { get; set; }
        public virtual DbSet<DANHMUC> DANHMUCs { get; set; }
        public virtual DbSet<DONHANG> DONHANGs { get; set; }
        public virtual DbSet<GIAMGIA> GIAMGIAs { get; set; }
        public virtual DbSet<GIOHANG> GIOHANGs { get; set; }
        public virtual DbSet<HINHTHUCTHANHTOAN> HINHTHUCTHANHTOANs { get; set; }
        public virtual DbSet<HINHTHUCVANCHUYEN> HINHTHUCVANCHUYENs { get; set; }
        public virtual DbSet<KHOHANG> KHOHANGs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<SANPHAM> SANPHAMs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOANs { get; set; }
        public virtual DbSet<THUONGHIEU> THUONGHIEUx { get; set; }
        public virtual DbSet<TINNHAN> TINNHANs { get; set; }
        public virtual DbSet<TINTUC> TINTUCs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BINHLUAN>()
                .Property(e => e.NoiDung)
                .IsUnicode(false);

            modelBuilder.Entity<BINHLUAN>()
                .Property(e => e.Email)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETDONHANG>()
                .Property(e => e.GiaMua)
                .HasPrecision(10, 0);

            modelBuilder.Entity<CHITIETGIAMGIA>()
                .Property(e => e.MucGiamGia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CHITIETGIAMGIA>()
                .Property(e => e.Giamua)
                .HasPrecision(10, 0);

            modelBuilder.Entity<CHITIETGIOHANG>()
                .Property(e => e.MaGioHang)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETGIOHANG>()
                .Property(e => e.Giaban)
                .HasPrecision(10, 0);

            modelBuilder.Entity<CUAHANG>()
                .Property(e => e.SoDienThoai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CUAHANG>()
                .HasMany(e => e.KHOHANGs)
                .WithRequired(e => e.CUAHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CUAHANG>()
                .HasMany(e => e.NHANVIENs)
                .WithRequired(e => e.CUAHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CUAHANG>()
                .HasMany(e => e.TINNHANs)
                .WithRequired(e => e.CUAHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DANHGIA>()
                .Property(e => e.NoiDungDanhGia)
                .IsUnicode(false);

            modelBuilder.Entity<DANHGIA>()
                .Property(e => e.Email)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DANHMUC>()
                .HasMany(e => e.SANPHAMs)
                .WithRequired(e => e.DANHMUC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DONHANG>()
                .Property(e => e.DiaChiGiao)
                .IsUnicode(false);

            modelBuilder.Entity<DONHANG>()
                .Property(e => e.GhiChu)
                .IsUnicode(false);

            modelBuilder.Entity<DONHANG>()
                .Property(e => e.TinhTrangThanhToan)
                .IsUnicode(false);

            modelBuilder.Entity<DONHANG>()
                .Property(e => e.TinhTrangGiaoHang)
                .IsUnicode(false);

            modelBuilder.Entity<DONHANG>()
                .HasMany(e => e.CHITIETDONHANGs)
                .WithRequired(e => e.DONHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GIAMGIA>()
                .Property(e => e.MoTa)
                .IsUnicode(false);

            modelBuilder.Entity<GIAMGIA>()
                .HasMany(e => e.CHITIETGIAMGIAs)
                .WithRequired(e => e.GIAMGIA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GIOHANG>()
                .Property(e => e.MaGioHang)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GIOHANG>()
                .HasMany(e => e.CHITIETGIOHANGs)
                .WithRequired(e => e.GIOHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HINHTHUCTHANHTOAN>()
                .Property(e => e.MoTa)
                .IsUnicode(false);

            modelBuilder.Entity<HINHTHUCTHANHTOAN>()
                .HasMany(e => e.DONHANGs)
                .WithRequired(e => e.HINHTHUCTHANHTOAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HINHTHUCVANCHUYEN>()
                .Property(e => e.MoTa)
                .IsUnicode(false);

            modelBuilder.Entity<HINHTHUCVANCHUYEN>()
                .HasMany(e => e.DONHANGs)
                .WithRequired(e => e.HINHTHUCVANCHUYEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.TINTUCs)
                .WithRequired(e => e.NHANVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.GiaTien)
                .HasPrecision(10, 0);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.MoTa)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.CHITIETDONHANGs)
                .WithRequired(e => e.SANPHAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.CHITIETGIAMGIAs)
                .WithRequired(e => e.SANPHAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.CHITIETGIOHANGs)
                .WithRequired(e => e.SANPHAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.DANHGIAs)
                .WithRequired(e => e.SANPHAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.KHOHANGs)
                .WithRequired(e => e.SANPHAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.Email)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.MatKhau)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.PhanQuyen)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .HasMany(e => e.DONHANGs)
                .WithRequired(e => e.TAIKHOAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THUONGHIEU>()
                .HasMany(e => e.SANPHAMs)
                .WithRequired(e => e.THUONGHIEU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TINNHAN>()
                .Property(e => e.Email)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TINNHAN>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TINTUC>()
                .Property(e => e.NoiDung)
                .IsUnicode(false);

            modelBuilder.Entity<TINTUC>()
                .Property(e => e.HinhAnh)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TINTUC>()
                .HasMany(e => e.BINHLUANs)
                .WithRequired(e => e.TINTUC)
                .WillCascadeOnDelete(false);
        }
    }
}
