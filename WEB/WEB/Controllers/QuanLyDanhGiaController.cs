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
    public class QuanLyDanhGiaController : Controller
    {
        private Model1 db = new Model1();
        public ActionResult QuanLyDanhGia()
        {
            if (Session["Phanquyen"] != null && string.Equals((string)Session["Phanquyen"], "admin", StringComparison.OrdinalIgnoreCase))
            {
                return View(db.DANHGIAs.ToList());
            }
            else
            {
                return RedirectToAction("DangNhap", "DangNhap");
            }

        }
        public ActionResult XoaDanhGia(int? id)
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANHGIA danhgia = db.DANHGIAs.Find(id);
            if (danhgia == null)
            {
                return HttpNotFound();
            }
            return View(danhgia);
        }

        [HttpPost, ActionName("XoaDanhGia")]
        [ValidateAntiForgeryToken]
        public ActionResult XoaDanhGiaConfirmed(int id)
        {
            DANHGIA danhgia = db.DANHGIAs.Find(id);
            db.DANHGIAs.Remove(danhgia);
            db.SaveChanges();
            return RedirectToAction("QuanLyDanhGia");
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