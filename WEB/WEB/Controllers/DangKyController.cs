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
    public class DangKyController : Controller
    {
        private Model1 db = new Model1();
        // GET: DangKy
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KiemTraDangKy(String Ho, String Ten, String Email, String SDT, String Password)
        {
            try
            {
                TAIKHOAN x = new TAIKHOAN();
                int ID;
                if (db.TAIKHOANs.Select(p => p) == null)
                {
                    ID = 1;
                }
                else
                {
                    ID = db.TAIKHOANs.Max(p => p.ID) + 1;
                }
                x.ID = ID;
                x.Ho = Ho;
                x.Ten = Ten;
                x.Email = Email;
                x.SDT = SDT;
                x.MatKhau = Password;
                x.PhanQuyen = "user";
                db.TAIKHOANs.Add(x);
                db.SaveChanges();
               Session["DKTT"] = "Bạn đã đăng ký thành công tài khoản";
                return RedirectToAction("DangNhap","DangNhap");
            }
            catch (Exception e)
            {
                ViewBag.Message = "Error:" + e.Message;
                return View("DangKy");
            }


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