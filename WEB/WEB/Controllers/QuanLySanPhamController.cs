using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WEB.Models;
using System.IO;


namespace WEB.Controllers
{
    public class QuanLySanPhamController : Controller
    {
        // GET: QuanLySanPham
        private Model1 db = new Model1();
        public ActionResult QuanLySanPham()
        {
            if (Session["Phanquyen"] != null && string.Equals((string)Session["Phanquyen"], "admin", StringComparison.OrdinalIgnoreCase))
            {
                return View(db.SANPHAMs.ToList());
            }
            else
            {
                return RedirectToAction("DangNhap", "DangNhap");
            }

        }

        public ActionResult TaoSanPham()
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            ViewBag.MaDanhMuc = new SelectList(db.DANHMUCs, "MaDanhMuc", "TenDanhMuc");
            ViewBag.MaThuongHieu = new SelectList(db.THUONGHIEUx, "MaThuongHieu", "TenThuongHieu");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TaoSanPham([Bind(Include = "TenSanPham,HinhAnh,GiaTien,DungTich,MoTa,MaDanhMuc,MaThuongHieu")] SANPHAM sp, HttpPostedFileBase HinhAnh)
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (ModelState.IsValid)
            {
                if (HinhAnh != null && HinhAnh.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(HinhAnh.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/SanPhamImage/"), fileName);
                    HinhAnh.SaveAs(path);
                    sp.HinhAnh = fileName; // Lưu tên tệp hình ảnh vào thuộc tính HinhAnh
                }
                var existingIds = db.SANPHAMs.Select(p => p.MaSanPham).ToList();
                int newId = 1;

                // Tìm giá trị nhỏ nhất không có trong danh sách mã sản phẩm hiện có
                while (existingIds.Contains(newId))
                {
                    newId++;
                }
                sp.MaSanPham = newId;
                db.SANPHAMs.Add(sp);
                db.SaveChanges();
                return RedirectToAction("QuanLySanPham");
            }
            ViewBag.MaDanhMuc = new SelectList(db.DANHMUCs, "MaDanhMuc", "TenDanhMuc", sp.MaDanhMuc);
            ViewBag.MaThuongHieu = new SelectList(db.THUONGHIEUx, "MaThuongHieu", "TenThuongHieu", sp.MaThuongHieu);
            return View(sp);
        }

        public ActionResult SuaSanPham(int? id)
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sanpham = db.SANPHAMs.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDanhMuc = new SelectList(db.DANHMUCs, "MaDanhMuc", "TenDanhMuc", sanpham.MaDanhMuc);
            ViewBag.MaThuongHieu = new SelectList(db.THUONGHIEUx, "MaThuongHieu", "TenThuongHieu", sanpham.MaThuongHieu);
            return View(sanpham);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaSanPham([Bind(Include = "MaSanPham, TenSanPham, HinhAnh, GiaTien, DungTich, MoTa, MaDanhMuc, MaThuongHieu")] SANPHAM sanpham, HttpPostedFileBase HinhAnh, string CurrentHinhAnh)
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (ModelState.IsValid)
            {
                if (HinhAnh != null && HinhAnh.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(HinhAnh.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/SanPhamImage/"), fileName);
                    HinhAnh.SaveAs(path);
                    sanpham.HinhAnh = fileName; // Lưu tên tệp hình ảnh vào thuộc tính HinhAnh
                }
                else
                {
                    sanpham.HinhAnh = CurrentHinhAnh; // Giữ lại hình ảnh hiện tại nếu không chọn hình ảnh mới
                }

                db.Entry(sanpham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("QuanLySanPham");
            }
            ViewBag.MaDanhMuc = new SelectList(db.DANHMUCs, "MaDanhMuc", "TenDanhMuc", sanpham.MaDanhMuc);
            ViewBag.MaThuongHieu = new SelectList(db.THUONGHIEUx, "MaThuongHieu", "TenThuongHieu", sanpham.MaThuongHieu);
            return View(sanpham);
        }
        public ActionResult XoaSanPham(int? id)
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sanpham = db.SANPHAMs.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            return View(sanpham);
        }

        [HttpPost, ActionName("XoaSanPham")]
        [ValidateAntiForgeryToken]
        public ActionResult XoaSanPhamConfirmed(int id)
        {
            SANPHAM sanpham = db.SANPHAMs.Find(id);
            db.SANPHAMs.Remove(sanpham);
            db.SaveChanges();
            return RedirectToAction("QuanLySanPham");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}