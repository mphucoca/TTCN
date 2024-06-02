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
    public class QuanLyDanhMucController : Controller
    {
        // GET: QuanLyDanhMuc
        private Model1 db = new Model1();
        public ActionResult QuanLyDanhMuc()
        {
            if (Session["Phanquyen"] != null && string.Equals((string)Session["Phanquyen"], "admin", StringComparison.OrdinalIgnoreCase))
            {
                return View(db.DANHMUCs.ToList());
            }
            else
            {
                return RedirectToAction("DangNhap", "DangNhap");
            }

        }

        public ActionResult TaoDanhMuc()
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TaoDanhMuc([Bind(Include = "TenDanhMuc")] DANHMUC danhmuc)
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (ModelState.IsValid)
            {
                var existingIds = db.DANHMUCs.Select(p => p.MaDanhMuc).ToList();
                int newId = 1;

                // Tìm giá trị nhỏ nhất không có trong danh sách mã sản phẩm hiện có
                while (existingIds.Contains(newId))
                {   
                    newId++;
                }
                danhmuc.MaDanhMuc = newId;
                db.DANHMUCs.Add(danhmuc);
                db.SaveChanges();
                return RedirectToAction("QuanLyDanhMuc");
            }

            return View(danhmuc);
        }

        public ActionResult SuaDanhMuc(int? id)
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANHMUC danhmuc = db.DANHMUCs.Find(id);
            if (danhmuc == null)
            {
                return HttpNotFound();
            }
            return View(danhmuc);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaDanhMuc([Bind(Include = "MaDanhMuc,TenDanhMuc")] DANHMUC danhmuc)
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (ModelState.IsValid)
            {
                db.Entry(danhmuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("QuanLyDanhMuc");
            }
            return View(danhmuc);
        }

        public ActionResult XoaDanhMuc(int? id)
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANHMUC danhmuc = db.DANHMUCs.Find(id);
            if (danhmuc == null)
            {
                return HttpNotFound();
            }
            return View(danhmuc);
        }

        [HttpPost, ActionName("XoaDanhMuc")]
        [ValidateAntiForgeryToken]
        public ActionResult XoaDanhMucConfirmed(int id)
        {
            DANHMUC danhmuc = db.DANHMUCs.Find(id);

            db.DANHMUCs.Remove(danhmuc);
            db.SaveChanges();
            return RedirectToAction("QuanLyDanhMuc");
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