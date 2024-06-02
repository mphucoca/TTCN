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
    public class DangXuatController : Controller
    {
        // GET: DangXuat
        public ActionResult DangXuat()
        {
             
                Session.Remove("Hoten");
                Session.Remove("username");
                Session.Remove("Phanquyen");
                return RedirectToAction("DangNhap","DangNhap");
 
        }
    }
}