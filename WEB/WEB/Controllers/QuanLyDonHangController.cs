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
    public class QuanLyDonHangController : Controller
    {
        // GET: DonHangCuaBan
        private Model1 db = new Model1();
        public ActionResult QuanLyDonHang()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("DangNhap", "DangNhap");
            }
             return View(db.DONHANGs.ToList());
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
        [HttpPost]
        public JsonResult UpdateOrderStatus(int orderId, string paymentStatus, string deliveryStatus)
        {
            var order = db.DONHANGs.Find(orderId);
            if (order == null)
            {
                return Json(new { success = false, message = "Order not found" });
            }

            order.TinhTrangThanhToan = paymentStatus;
            order.TinhTrangGiaoHang = deliveryStatus;

            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();

            return Json(new { success = true });
        }
    }
}