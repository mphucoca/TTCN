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
    public class QuanLyHinhThucVanChuyenController : Controller
    {
        private Model1 db = new Model1();
        public ActionResult QuanLyHinhThucVanChuyen()
        {
            if (Session["Phanquyen"] != null && string.Equals((string)Session["Phanquyen"], "admin", StringComparison.OrdinalIgnoreCase))
            {
                return View(db.HINHTHUCVANCHUYENs.ToList());
            }
            else
            {
                return RedirectToAction("DangNhap", "DangNhap");
            }

        }

        public ActionResult TaoHinhThucVanChuyen()
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TaoHinhThucVanChuyen([Bind(Include = "TenHinhThucVanChuyen,MoTa")] HINHTHUCVANCHUYEN vanchuyen)
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (ModelState.IsValid)
            {
                var existingIds = db.HINHTHUCVANCHUYENs.Select(p => p.MaHinhThucVanChuyen).ToList();
                int newId = 1;

                // Tìm giá trị nhỏ nhất không có trong danh sách mã sản phẩm hiện có
                while (existingIds.Contains(newId))
                {
                    newId++;
                }
                vanchuyen.MaHinhThucVanChuyen = newId;
                db.HINHTHUCVANCHUYENs.Add(vanchuyen);
                db.SaveChanges();
                return RedirectToAction("QuanLyHinhThucVanChuyen");
            }
            return View(vanchuyen);
        }

        public ActionResult SuaHinhThucVanChuyen(int? id)
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HINHTHUCVANCHUYEN vanchuyen = db.HINHTHUCVANCHUYENs.Find(id);
            if (vanchuyen == null)
            {
                return HttpNotFound();
            }
            return View(vanchuyen);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaHinhThucVanChuyen([Bind(Include = "MaHinhThucVanChuyen,TenHinhThucVanChuyen,MoTa")] HINHTHUCVANCHUYEN vanchuyen)
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (ModelState.IsValid)
            {
                db.Entry(vanchuyen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("QuanLyHinhThucVanChuyen");
            }
            return View(vanchuyen);
        }

        public ActionResult XoaHinhThucVanChuyen(int? id)
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HINHTHUCVANCHUYEN vanchuyen = db.HINHTHUCVANCHUYENs.Find(id);

            if (vanchuyen == null)
            {
                return HttpNotFound();
            }
            return View(vanchuyen);
        }

        [HttpPost, ActionName("XoaHinhThucVanChuyen")]
        [ValidateAntiForgeryToken]
        public ActionResult XoaHinhThucVanChuyenConfirmed(int id)
        {
            HINHTHUCVANCHUYEN vanchuyen = db.HINHTHUCVANCHUYENs.Find(id);


            db.HINHTHUCVANCHUYENs.Remove(vanchuyen);
            db.SaveChanges();
            return RedirectToAction("QuanLyHinhThucVanChuyen");
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