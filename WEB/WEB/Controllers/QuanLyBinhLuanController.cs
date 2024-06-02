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
    public class QuanLyBinhLuanController : Controller
    {
        private Model1 db = new Model1();
        public ActionResult QuanLyBinhLuan()
        {
            if (Session["Phanquyen"] != null && string.Equals((string)Session["Phanquyen"], "admin", StringComparison.OrdinalIgnoreCase))
            {
                return View(db.BINHLUANs.ToList());
            }
            else
            {
                return RedirectToAction("DangNhap", "DangNhap");
            }

        }
        public ActionResult XoaBinhLuan(int? id)
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BINHLUAN binhluan = db.BINHLUANs.Find(id);
            if (binhluan == null)
            {
                return HttpNotFound();
            }
            return View(binhluan);
        }

        [HttpPost, ActionName("XoaBinhLuan")]
        [ValidateAntiForgeryToken]
        public ActionResult XoaBinhLuanConfirmed(int id)
        {
            BINHLUAN binhluan = db.BINHLUANs.Find(id);

            db.BINHLUANs.Remove(binhluan);
            db.SaveChanges();
            return RedirectToAction("QuanLyBinhLuan");
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