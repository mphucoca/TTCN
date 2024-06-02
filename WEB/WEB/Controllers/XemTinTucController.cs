
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
    public class XemTinTucController : Controller
    {
        private Model1 db = new Model1();

        // GET: TINTUCs
        public ActionResult DanhSachTinTuc()
        {
            if (db.TINTUCs.ToList() == null)
            {
                ViewBag.Message = "Không có dữ liệu về tin tức nào";
            }
            return View(db.TINTUCs.ToList());
        }

        // GET: TINTUCs/Details/5
        public ActionResult ChiTietTinTuc(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TINTUC tINTUC = db.TINTUCs.Find(id);
            if (tINTUC == null)
            {
                return HttpNotFound();
            }
            return View(tINTUC);
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