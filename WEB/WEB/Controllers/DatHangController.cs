using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WEB.Models;

namespace WEB.Controllers
{
    public class DatHangController : Controller
    {
        private Model1 db = new Model1();

        // GET: DatHang
        public ActionResult DatHang()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("DangNhap", "DangNhap");
            }

            int ID = (int)Session["username"];
            if (!db.CHITIETGIOHANGs.Any(p => p.GIOHANG.ID == ID))
            {
                return RedirectToAction("XemGioHang", "XemGioHang");
            }

            var chiTietGioHang = db.CHITIETGIOHANGs.Include(p => p.SANPHAM).Where(p => p.GIOHANG.ID == ID);

            ViewBag.PhuongThucThanhToan = db.HINHTHUCTHANHTOANs.ToList();
            ViewBag.PhuongThucVanChuyen = db.HINHTHUCVANCHUYENs.ToList();
            var TTND = db.TAIKHOANs.FirstOrDefault(p => p.ID == ID);
            ViewBag.hoten = TTND?.Ho + " " + TTND?.Ten;
            ViewBag.email = TTND?.Email;
            ViewBag.sodienthoai = TTND?.SDT;

            int tongdongia = 0;
            foreach (var item in chiTietGioHang)
            {
                if (item.SANPHAM.CHITIETGIAMGIAs.Any(ct => ct.MaSanPham == item.MaSanPham && (ct.Giamua == null || ct.Giamua == 0) && ct.GIAMGIA.NgayKetThuc > DateTime.Today && ct.GIAMGIA.NgayBatDau < DateTime.Today))
                {
                    var chitiet = item.SANPHAM.CHITIETGIAMGIAs.FirstOrDefault(ct => ct.MaSanPham == item.MaSanPham && (ct.Giamua == null || ct.Giamua == 0));
                    var giamGia = chitiet.MucGiamGia;
                    var giaMoi = item.SANPHAM.GiaTien - (item.SANPHAM.GiaTien * giamGia / 100);
                    tongdongia += (int)giaMoi;
                }
                else
                {
                    var giaMoi = item.SANPHAM.GiaTien;
                    tongdongia += (int)giaMoi;
                }
            }

            var voucherlist = db.GIAMGIAs
                .Where(d => d.NgayBatDau <= DateTime.Now && d.NgayKetThuc >= DateTime.Now)
                .Where(d => d.CHITIETGIAMGIAs.Any(ct => ct.Giamua != null && ct.Giamua != 0))
                .Where(d => d.CHITIETGIAMGIAs.Any(ct => ct.MucGiamGia <= 100 || tongdongia >= ct.Giamua))
                .ToList();

            ViewBag.voucherlist = voucherlist;

            return View(chiTietGioHang.ToList());
        }

        // POST: DonHang/DatHang
        [HttpPost]
        public ActionResult DatHang(string DiaChi, string ghichu, int? MaGiamGia, int MaHinhThucThanhToan, int MaHinhThucVanChuyen)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("DangNhap", "DangNhap");
            }

            int userId = (int)Session["username"];
            var user = db.TAIKHOANs.FirstOrDefault(p => p.ID == userId);

            if (user == null)
            {
                return RedirectToAction("DangNhap", "DangNhap");
            }

            DONHANG newDonHang = new DONHANG
            {
                MaDonHang = db.DONHANGs.Any() ? db.DONHANGs.Max(p => p.MaDonHang) + 1 : 1,
                ID = userId,
                DiaChiGiao = DiaChi,
                GhiChu = ghichu,
                NgayDatHang = DateTime.Today,
                MaHinhThucThanhToan = MaHinhThucThanhToan,
                MaHinhThucVanChuyen = MaHinhThucVanChuyen,
                TinhTrangGiaoHang = "Chờ Xác Nhận",
                TinhTrangThanhToan = "Chưa Thanh Toán"
            };

            var chiTietGioHang = db.CHITIETGIOHANGs.Include(p => p.SANPHAM).Where(p => p.GIOHANG.ID == userId);

            foreach (var item in chiTietGioHang)
            {
                CHITIETDONHANG chitietdonhang = new CHITIETDONHANG
                {
                    MaSanPham = item.MaSanPham,
                    MaDonHang = newDonHang.MaDonHang,
                    SoLuongMua = item.SoLuong
                };

                if (item.SANPHAM.CHITIETGIAMGIAs.Any(ct => ct.MaSanPham == item.MaSanPham && (ct.Giamua == null || ct.Giamua == 0) && ct.GIAMGIA.NgayKetThuc > DateTime.Today && ct.GIAMGIA.NgayBatDau < DateTime.Today))
                {
                    var chitiet = item.SANPHAM.CHITIETGIAMGIAs.FirstOrDefault(ct => ct.MaSanPham == item.MaSanPham && (ct.Giamua == null || ct.Giamua == 0));
                    var giamGia = chitiet.MucGiamGia;
                    chitietdonhang.GiaMua = item.SANPHAM.GiaTien - (item.SANPHAM.GiaTien * giamGia / 100);
                }
                else
                {
                    chitietdonhang.GiaMua = item.SANPHAM.GiaTien;
                }

                db.CHITIETDONHANGs.Add(chitietdonhang);
            }

            if (MaGiamGia.HasValue)
            {
                newDonHang.MaGiamGia = MaGiamGia.Value;
            }

            db.DONHANGs.Add(newDonHang);
            db.SaveChanges();
            return RedirectToAction("ChiTietDonHang", "DonHangCuaBan", new { id = newDonHang.MaDonHang });
        }
 
    }
}
