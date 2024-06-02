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
    public class QuanLyNhanVienController : Controller
    {
        private Model1 db = new Model1();
        public ActionResult QuanLyNhanVien()
        {
            if (Session["Phanquyen"] != null && string.Equals((string)Session["Phanquyen"], "admin", StringComparison.OrdinalIgnoreCase))
            {
                return View(db.NHANVIENs.ToList());
            }
            else
            {
                return RedirectToAction("DangNhap", "DangNhap");
            }

        }
        public ActionResult TaoNhanVien()
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            ViewBag.MaCuaHang = new SelectList(db.CUAHANGs, "MaCuaHang", "TenCuaHang");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TaoNhanVien([Bind(Include = "HoTen,SDT,DiaChi,MaCuaHang")] NHANVIEN nhanvien)
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (ModelState.IsValid)
            {
                var existingIds = db.NHANVIENs.Select(p => p.MaNhanVien).ToList();
                int newId = 1;

                // Tìm giá trị nhỏ nhất không có trong danh sách mã sản phẩm hiện có
                while (existingIds.Contains(newId))
                {
                    newId++;
                }
                nhanvien.MaNhanVien = newId;
                db.NHANVIENs.Add(nhanvien);
                db.SaveChanges();
                return RedirectToAction("QuanLyNhanVien");
            }

            ViewBag.MaCuaHang = new SelectList(db.CUAHANGs, "MaCuaHang", "TenCuaHang");

            return View(nhanvien);
        }

        public ActionResult SuaNhanVien(int? id)
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nhanvien = db.NHANVIENs.Find(id);
            if (nhanvien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaCuaHang = new SelectList(db.CUAHANGs, "MaCuaHang", "TenCuaHang");


            return View(nhanvien);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaNhanVien([Bind(Include = "MaNhanVien,HoTen,DiaChi,SDT,MaCuaHang")] NHANVIEN nhanvien)
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (ModelState.IsValid)
            {

                db.Entry(nhanvien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("QuanLyNhanVien");
            }
            ViewBag.MaCuaHang = new SelectList(db.CUAHANGs, "MaCuaHang", "TenCuaHang");


            return View(nhanvien);
        }
        public ActionResult  XoaNhanVien (int? id)
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nhanvien = db.NHANVIENs.Find(id);



            if (nhanvien == null)
            {
                return HttpNotFound();
            }
            return View(nhanvien);
        }

        [HttpPost, ActionName("XoaNhanVien")]
        [ValidateAntiForgeryToken]
        public ActionResult XoaNhanVienConfirmed(int id)
        {
            NHANVIEN nhanvien = db.NHANVIENs.Find(id);



            db.NHANVIENs.Remove(nhanvien);
            db.SaveChanges();
            return RedirectToAction("QuanLyNhanVien");
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