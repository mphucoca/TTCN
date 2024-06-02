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
    public class LienHeController : Controller
    {
        private Model1 db = new Model1();

        // GET: LienHe
    
        public ActionResult LienHe()
        {
            return View();
        }

        public ActionResult Nhantinnhan()
        {
            try
            {
                int matinnhan;
                if (db.TINNHANs.Select(p => p) == null)
                {
                    matinnhan = 1;
                }
                else
                {
                    matinnhan = db.TINNHANs.Max(p => p.MaTinNhan) + 1;
                }
                string hoten = Request["HoTen"];
                string email = Request["Email"];
                string sodienthoai = Request["DienThoai"];
                string noidung = Request["NoiDung"];

                TINNHAN x = new TINNHAN();
                x.MaTinNhan = matinnhan;
                x.Hoten = hoten;
                x.Email = email;
                x.SDT = sodienthoai;
                x.NoiDung = noidung;

                List<CUAHANG> list = db.CUAHANGs.ToList();
                x.MaCuaHang = list[0].MaCuaHang;

                db.TINNHANs.Add(x);
                db.SaveChanges();
                ViewBag.SuccessMessage = "Đã gửi tin nhắn thành công";
            }
            catch (Exception e)
            {
                ViewBag.result = "no";
                ViewBag.SuccessMessage = "Thất bại: " + e.Message;
            }
            return View("LienHe");
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