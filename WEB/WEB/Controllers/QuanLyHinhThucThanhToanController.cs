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
    public class QuanLyHinhThucThanhToanController : Controller
    {
        private Model1 db = new Model1();
        public ActionResult QuanLyHinhThucThanhToan()
        {
            if (Session["Phanquyen"] != null && string.Equals((string)Session["Phanquyen"], "admin", StringComparison.OrdinalIgnoreCase))
            {
                return View(db.HINHTHUCTHANHTOANs.ToList());
            }
            else
            {
                return RedirectToAction("DangNhap", "DangNhap");
            }

        }

        public ActionResult TaoHinhThucThanhToan()
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TaoHinhThucThanhToan([Bind(Include = "TenHinhThucThanhToan,MoTa")] HINHTHUCTHANHTOAN thanhtoan)
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (ModelState.IsValid)
            {
                var existingIds = db.HINHTHUCTHANHTOANs.Select(p => p.MaHinhThucThanhToan).ToList();
                int newId = 1;

                // Tìm giá trị nhỏ nhất không có trong danh sách mã sản phẩm hiện có
                while (existingIds.Contains(newId))
                {
                    newId++;
                }
                thanhtoan.MaHinhThucThanhToan = newId;
                db.HINHTHUCTHANHTOANs.Add(thanhtoan);
                db.SaveChanges();
                return RedirectToAction("QuanLyHinhThucThanhToan");
            }
            return View(thanhtoan);
        }

        public ActionResult SuaHinhThucThanhToan(int? id)
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HINHTHUCTHANHTOAN thanhtoan = db.HINHTHUCTHANHTOANs.Find(id);
            if (thanhtoan == null)
            {
                return HttpNotFound();
            }
            return View(thanhtoan);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaHinhThucThanhToan([Bind(Include = "MaHinhThucThanhToan,TenHinhThucThanhToan,MoTa")] HINHTHUCTHANHTOAN thanhtoan)
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (ModelState.IsValid)
            {
                db.Entry(thanhtoan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("QuanLyHinhThucThanhToan");
            }
            return View(thanhtoan);
        }

        public ActionResult XoaHinhThucThanhToan(int? id)
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HINHTHUCTHANHTOAN thanhtoan = db.HINHTHUCTHANHTOANs.Find(id);


            if (thanhtoan == null)
            {
                return HttpNotFound();
            }
            return View(thanhtoan);
        }

        [HttpPost, ActionName("XoaHinhThucThanhToan")]
        [ValidateAntiForgeryToken]
        public ActionResult XoaHinhThucThanhToanConfirmed(int id)
        {
            HINHTHUCTHANHTOAN thanhtoan = db.HINHTHUCTHANHTOANs.Find(id);


            db.HINHTHUCTHANHTOANs.Remove(thanhtoan);
            db.SaveChanges();
            return RedirectToAction("QuanLyHinhThucThanhToan");
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