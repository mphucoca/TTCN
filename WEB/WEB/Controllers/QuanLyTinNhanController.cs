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
    public class QuanLyTinNhanController : Controller
    {
        private Model1 db = new Model1();
        public ActionResult QuanLyTinNhan()
        {
            if (Session["Phanquyen"] != null && string.Equals((string)Session["Phanquyen"], "admin", StringComparison.OrdinalIgnoreCase))
            {
                return View(db.TINNHANs.ToList());
            }
            else
            {
                return RedirectToAction("DangNhap", "DangNhap");
            }

        }
        public ActionResult TaoTinNhan()
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
        public ActionResult TaoTinNhan([Bind(Include = "HoTen,Email,SDT,NoiDung,MaCuaHang")] TINNHAN tinnhan)
        {
             if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (ModelState.IsValid)
            {
                var existingIds = db.TINNHANs.Select(p => p.MaTinNhan).ToList();
                int newId = 1;

                // Tìm giá trị nhỏ nhất không có trong danh sách mã sản phẩm hiện có
                while (existingIds.Contains(newId))
                {
                    newId++;
                }
                tinnhan.MaTinNhan = newId;
                db.TINNHANs.Add(tinnhan);
                db.SaveChanges();
                return RedirectToAction("QuanLyTinNhan");
            }

            ViewBag.MaCuaHang = new SelectList(db.CUAHANGs, "MaCuaHang", "TenCuaHang");

            return View(tinnhan);
        }

        public ActionResult SuaTinNhan(int? id)
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TINNHAN tinnhan = db.TINNHANs.Find(id);
            if (tinnhan == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaCuaHang = new SelectList(db.CUAHANGs, "MaCuaHang", "TenCuaHang");


            return View(tinnhan);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaTinNhan([Bind(Include = "MaTinNhan,HoTen,Email,SDT,NoiDung,MaCuaHang")] TINNHAN tinnhan)
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (ModelState.IsValid)
            {
                
                db.Entry(tinnhan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("QuanLyTinNhan");
            }
            ViewBag.MaCuaHang = new SelectList(db.CUAHANGs, "MaCuaHang", "TenCuaHang");


            return View(tinnhan);
        }
        public ActionResult XoaTinNhan(int? id)
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TINNHAN tinnhan = db.TINNHANs.Find(id);


            if (tinnhan == null)
            {
                return HttpNotFound();
            }
            return View(tinnhan);
        }

        [HttpPost, ActionName("XoaTinNhan")]
        [ValidateAntiForgeryToken]
        public ActionResult XoaTinNhanConfirmed(int id)
        {
            TINNHAN tinnhan = db.TINNHANs.Find(id);


            db.TINNHANs.Remove(tinnhan);
            db.SaveChanges();
            return RedirectToAction("QuanLyTinNhan");
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