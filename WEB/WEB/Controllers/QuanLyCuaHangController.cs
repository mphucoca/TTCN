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
    public class QuanLyCuaHangController : Controller
    {
        private Model1 db = new Model1();
        public ActionResult QuanLyCuaHang()
        {
            if (Session["Phanquyen"] != null && string.Equals((string)Session["Phanquyen"], "admin", StringComparison.OrdinalIgnoreCase))
            {
                return View(db.CUAHANGs.ToList());
            }
            else
            {
                return RedirectToAction("DangNhap", "DangNhap");
            }

        }

        public ActionResult TaoCuaHang()
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TaoCuaHang([Bind(Include = "TenCuaHang,SoDienThoai,DiaChi")] CUAHANG cuahang)
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (ModelState.IsValid)
            {
                var existingIds = db.CUAHANGs.Select(p => p.MaCuaHang).ToList();
                int newId = 1;

                // Tìm giá trị nhỏ nhất không có trong danh sách mã sản phẩm hiện có
                while (existingIds.Contains(newId))
                {
                    newId++;
                }
                cuahang.MaCuaHang = newId;
                db.CUAHANGs.Add(cuahang);
                db.SaveChanges();
                return RedirectToAction("QuanLyCuaHang");
            }

            return View(cuahang);
        }

        public ActionResult SuaCuaHang(int? id)
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUAHANG cuahang = db.CUAHANGs.Find(id);
            if (cuahang == null)
            {
                return HttpNotFound();
            }
            return View(cuahang);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaCuaHang([Bind(Include = "MaCuaHang,TenCuaHang,DiaChi,SoDienThoai")] CUAHANG cuahang)
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (ModelState.IsValid)
            {
                db.Entry(cuahang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("QuanLyCuaHang");
            }
            return View(cuahang);
        }

        public ActionResult XoaCuaHang(int? id)
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUAHANG cuahang = db.CUAHANGs.Find(id);

            if (cuahang == null)
            {
                return HttpNotFound();
            }
            return View(cuahang);
        }

        [HttpPost, ActionName("XoaCuaHang")]
        [ValidateAntiForgeryToken]
        public ActionResult XoaCuaHangConfirmed(int id)
        {
            CUAHANG cuahang = db.CUAHANGs.Find(id);


            db.CUAHANGs.Remove(cuahang);
            db.SaveChanges();
            return RedirectToAction("QuanLyCuaHang");
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