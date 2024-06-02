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
    public class QuanLyThuongHieuController : Controller
    {
        private Model1 db = new Model1();
        public ActionResult QuanLyThuongHieu()
        {
            if (Session["Phanquyen"] != null && string.Equals((string)Session["Phanquyen"], "admin", StringComparison.OrdinalIgnoreCase))
            {
                return View(db.THUONGHIEUx.ToList());
            }
            else
            {
                return RedirectToAction("DangNhap", "DangNhap");
            }

        }

        public ActionResult TaoThuongHieu()
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TaoThuongHieu([Bind(Include = "TenThuongHieu")] THUONGHIEU thuonghieu)
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (ModelState.IsValid)
            {
                var existingIds = db.THUONGHIEUx.Select(p => p.MaThuongHieu).ToList();
                int newId = 1;

                // Tìm giá trị nhỏ nhất không có trong danh sách mã sản phẩm hiện có
                while (existingIds.Contains(newId))
                {
                    newId++;
                }

                thuonghieu.MaThuongHieu = newId;
                db.THUONGHIEUx.Add(thuonghieu);
                db.SaveChanges();
                return RedirectToAction("QuanLyThuongHieu");
            }

            return View(thuonghieu);
        }

        public ActionResult SuaThuongHieu(int? id)
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THUONGHIEU thuonghieu = db.THUONGHIEUx.Find(id);
            if (thuonghieu == null)
            {
                return HttpNotFound();
            }
            return View(thuonghieu);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaThuongHieu([Bind(Include = "MaThuongHieu,TenThuongHieu")] THUONGHIEU thuonghieu)
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (ModelState.IsValid)
            {
                db.Entry(thuonghieu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("QuanLyThuongHieu");
            }
            return View(thuonghieu);
        }

        public ActionResult XoaThuongHieu(int? id)
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THUONGHIEU thuonghieu = db.THUONGHIEUx.Find(id);
            if (thuonghieu == null)
            {
                return HttpNotFound();
            }
            return View(thuonghieu);
        }

        [HttpPost, ActionName("XoaThuongHieu")]
        [ValidateAntiForgeryToken]
        public ActionResult XoaThuongHieuConfirmed(int id)
        {
            THUONGHIEU thuonghieu = db.THUONGHIEUx.Find(id);


            db.THUONGHIEUx.Remove(thuonghieu);
            db.SaveChanges();
            return RedirectToAction("QuanLyThuongHieu");
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
