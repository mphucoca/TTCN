using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEB.Controllers
{
    public class QuanLyWebsiteController : Controller
    {
        // GET: QuanLyWebsite
        public ActionResult Index()
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            return View();
        }
    }
}