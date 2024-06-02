using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WEB.Models;

namespace WEB.Controllers
{
    public class QuanLyGiamGiaController : Controller
    {
        private Model1 db = new Model1();

        public ActionResult QuanLyGiamGia()
        {
            if (Session["Phanquyen"] != null && string.Equals((string)Session["Phanquyen"], "admin", StringComparison.OrdinalIgnoreCase))
            {
                return View(db.GIAMGIAs.ToList());
            }
            else
            {
                return RedirectToAction("DangNhap", "DangNhap");
            }
        }

        public ActionResult TaoGiamGia()
        {
            if ((String)Session["Phanquyen"] != "admin")
            {
                return RedirectToAction("DangNhap", "DangNhap");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TaoGiamGia([Bind(Include = "MoTa,TenGiamGia,NgayBatDau,NgayKetThuc,SoLuong")] GIAMGIA giamgia)
        {
            if ((String)Session["Phanquyen"] != "admin")
            {
                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (ModelState.IsValid)
            {
                var existingIds = db.GIAMGIAs.Select(p => p.MaGiamGia).ToList();
                int newId = 1;

                // Tìm giá trị nhỏ nhất không có trong danh sách mã sản phẩm hiện có
                while (existingIds.Contains(newId))
                {
                    newId++;
                }
                giamgia.MaGiamGia = newId;
                db.GIAMGIAs.Add(giamgia);
                db.SaveChanges();
                return RedirectToAction("QuanLyGiamGia");
            }
            return View(giamgia);
        }

        public ActionResult SuaGiamGia(int? id)
        {
            if ((String)Session["Phanquyen"] != "admin")
            {
                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GIAMGIA giamgia = db.GIAMGIAs.Include(g => g.CHITIETGIAMGIAs.Select(ct => ct.SANPHAM)).FirstOrDefault(g => g.MaGiamGia == id);
            if (giamgia == null)
            {
                return HttpNotFound();
            }
            ViewBag.SanPhamList = new SelectList(db.SANPHAMs, "MaSanPham", "TenSanPham");
            return View(giamgia);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaGiamGia([Bind(Include = "MaGiamGia,MoTa,TenGiamGia,NgayBatDau,NgayKetThuc,SoLuong")] GIAMGIA giamgia)
        {
            if ((String)Session["Phanquyen"] != "admin")
            {
                return RedirectToAction("DangNhap", "DangNhap");
            }

            if (ModelState.IsValid)
            {
                db.Entry(giamgia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("QuanLyGiamGia");
            }
            ViewBag.SanPhamList = new SelectList(db.SANPHAMs, "MaSanPham", "TenSanPham");
            return View(giamgia);
        }

        public ActionResult XoaGiamGia(int? id)
        {
            if ((String)Session["Phanquyen"] != "admin")
            {
                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GIAMGIA giamgia = db.GIAMGIAs.Find(id);
            if (giamgia == null)
            {
                return HttpNotFound();
            }
            return View(giamgia);
        }

        [HttpPost, ActionName("XoaGiamGia")]
        [ValidateAntiForgeryToken]
        public ActionResult XoaGiamGiaConfirmed(int id)
        {
            GIAMGIA giamgia = db.GIAMGIAs.Find(id);
            db.GIAMGIAs.Remove(giamgia);
            db.SaveChanges();
            return RedirectToAction("QuanLyGiamGia");
        }
        private void PopulateSanPhamDropDownList(object selectedSanPham = null)
        {
            var sanPhamQuery = from s in db.SANPHAMs
                               orderby s.TenSanPham
                               select s;
            ViewBag.SanPhamList = new SelectList(sanPhamQuery, "MaSanPham", "TenSanPham", selectedSanPham);
        }

        public ActionResult ThemChiTietGiamGia(int maGiamGia)
        {
            ViewBag.GiamGiaId = maGiamGia;
            PopulateSanPhamDropDownList();
            return View(new CHITIETGIAMGIA { MaGiamGia = maGiamGia });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemChiTietGiamGia([Bind(Include = "MaSanPham,MaGiamGia,MucGiamGia,Giamua")] CHITIETGIAMGIA chiTietGiamGia)
        {
            if (ModelState.IsValid)
            {
                db.CHITIETGIAMGIAs.Add(chiTietGiamGia);
                db.SaveChanges();
                return RedirectToAction("SuaGiamGia", new { id = chiTietGiamGia.MaGiamGia });
            }
            ViewBag.GiamGiaId = chiTietGiamGia.MaGiamGia;
            PopulateSanPhamDropDownList(chiTietGiamGia.MaSanPham);
            return View(chiTietGiamGia);
        }

        public ActionResult SuaChiTietGiamGia(int maSanPham, int maGiamGia)
        {
            CHITIETGIAMGIA chiTietGiamGia = db.CHITIETGIAMGIAs.Find(maSanPham, maGiamGia);
            if (chiTietGiamGia == null)
            {
                return HttpNotFound();
            }
            ViewBag.GiamGiaId = chiTietGiamGia.MaGiamGia;
            PopulateSanPhamDropDownList(chiTietGiamGia.MaSanPham);
            return View(chiTietGiamGia);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaChiTietGiamGia([Bind(Include = "MaSanPham,MaGiamGia,MucGiamGia,Giamua")] CHITIETGIAMGIA chiTietGiamGia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietGiamGia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("SuaGiamGia", new { id = chiTietGiamGia.MaGiamGia });
            }
            ViewBag.GiamGiaId = chiTietGiamGia.MaGiamGia;
            PopulateSanPhamDropDownList(chiTietGiamGia.MaSanPham);
            return View(chiTietGiamGia);
        }

        public ActionResult XoaChiTietGiamGia(int maSanPham, int maGiamGia)
        {
            CHITIETGIAMGIA chiTietGiamGia = db.CHITIETGIAMGIAs.Find(maSanPham, maGiamGia);
            if (chiTietGiamGia == null)
            {
                return HttpNotFound();
            }
            ViewBag.GiamGiaId = chiTietGiamGia.MaGiamGia;
            return View(chiTietGiamGia);
        }

        [HttpPost, ActionName("XoaChiTietGiamGia")]
        [ValidateAntiForgeryToken]
        public ActionResult XoaChiTietGiamGiaConfirmed(int maSanPham, int maGiamGia)
        {
            CHITIETGIAMGIA chiTietGiamGia = db.CHITIETGIAMGIAs.Find(maSanPham, maGiamGia);
            db.CHITIETGIAMGIAs.Remove(chiTietGiamGia);
            db.SaveChanges();
            return RedirectToAction("SuaGiamGia", new { id = maGiamGia });
        }
    }
}
