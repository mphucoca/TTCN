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
    public class DangNhapController : Controller
    {
        private Model1 db = new Model1();
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KiemTraDangNhap(string username, string password)
        {
            if (Session["DKTT"] != null) { Session.Remove("DKTT"); }
            if (username == null || username.Trim() == "")
            {
                ViewBag.message = "Tên đăng nhập không được để trống";
                return View("DangNhap");
            }
            else if (password == null || password.Trim() == "")
            {
                ViewBag.message = "Mật khẩu không được để trống";
                return View("DangNhap");
            }
            else if (db.TAIKHOANs.Where(p => p.Email.Trim() == username.Trim() && p.MatKhau.Trim() == password.Trim()).FirstOrDefault() == null)
            {
                ViewBag.message = "Đăng nhập thất bại";
                return View("DangNhap");
            }
            else
            {
                TAIKHOAN taikhoan = db.TAIKHOANs.Where(p => p.Email.Trim() == username.Trim() && p.MatKhau.Trim() == password.Trim()).FirstOrDefault();
                Session["username"] = taikhoan.ID;
                Session["Hoten"] = taikhoan.Ho + " " + taikhoan.Ten;
                Session["Phanquyen"] = taikhoan.PhanQuyen.Trim();
                if(taikhoan.PhanQuyen.Trim()=="admin")
                {
                    return RedirectToAction("Index", "QuanLyWebsite");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
               
            }
        }
    }
}