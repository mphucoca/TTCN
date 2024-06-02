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
    public class KiemTraDonHangController : Controller
    {
        private Model1 db = new Model1();

        // GET: KiemTraDonHang
        public ActionResult KiemTraDonHang()
        {

            return View();
        }
        public ActionResult Kiemtra(String phone, String email)
        {

            List<DONHANG> list = new List<DONHANG>();
            if (email != null)
            {
                var orderWithEmail = db.DONHANGs.FirstOrDefault(p => p.TAIKHOAN.Email.Trim() == email.Trim());
                if (orderWithEmail != null)
                {
                    list.Add(orderWithEmail);
                }
            }
            if (phone != null)
            {
                var orderWithPhone = db.DONHANGs.FirstOrDefault(p => p.TAIKHOAN.SDT.Trim() == phone.Trim());
                if (orderWithPhone != null)
                {
                    list.Add(orderWithPhone);
                }
            }

            foreach(var item in list)
            {
                if (Session["username"] != null && Session["username"].ToString() == item.ID.ToString())
                {
                    ViewBag.TRUE = "TRUE";
                }
            }

            ViewBag.list = list;
            return View("KiemTraDonHang");
        }
        public ActionResult ChiTietDonHang(int? id)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int ID = (int)Session["username"];
            var TTND = db.TAIKHOANs.FirstOrDefault(p => p.ID == ID);
            ViewBag.hoten = TTND?.Ho + " " + TTND?.Ten;
            ViewBag.email = TTND?.Email;
            ViewBag.sodienthoai = TTND?.SDT;


            DONHANG dONHANG = db.DONHANGs.Find(id);
            ViewBag.list = db.CHITIETDONHANGs.Where(p => p.MaDonHang == dONHANG.MaDonHang).ToList();
            int TongThanhToan = 0;
            foreach (var item in db.CHITIETDONHANGs.Where(p => p.MaDonHang == dONHANG.MaDonHang).ToList())
            {
                TongThanhToan += (int)item.SoLuongMua * (int)item.GiaMua;
            }
            if (dONHANG.MaGiamGia != null)
            {
                CHITIETGIAMGIA x = db.CHITIETGIAMGIAs.Where(p => p.MaGiamGia == dONHANG.MaGiamGia).FirstOrDefault();
                if (x.MucGiamGia <= 100)
                {
                    TongThanhToan = TongThanhToan - TongThanhToan * (int)x.MucGiamGia / 100;
                }
                else
                {
                    TongThanhToan = TongThanhToan - (int)x.MucGiamGia;
                }
                ViewBag.giamgia = x;
            }




            ViewBag.TongThanhToan = TongThanhToan;
            if (dONHANG == null)
            {
                return HttpNotFound();
            }
            return View(dONHANG);
        }

    }
}

 











 

      
