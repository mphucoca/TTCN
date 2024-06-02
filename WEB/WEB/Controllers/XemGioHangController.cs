using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB.Models;
namespace WEB.Controllers
{
    public class XemGioHangController : Controller
    {
        private Model1 db = new Model1();
        // GET: XemGioHang
        public ActionResult XemGioHang()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("DangNhap", "DangNhap");
            }
            int ID = (int)Session["username"];
            GIOHANG x = db.GIOHANGs.Where(p => p.ID == ID).FirstOrDefault();
            if (x == null)
            {
                x = new GIOHANG();
                // Lấy mã giỏ hàng cuối cùng từ cơ sở dữ liệu
                var lastGioHang = db.GIOHANGs.OrderByDescending(p => p.MaGioHang).FirstOrDefault();
                string newMaGioHang;
                if (lastGioHang == null)
                {
                    // Nếu không có giỏ hàng nào trong cơ sở dữ liệu
                    newMaGioHang = "GH001";
                }
                else
                {
                    // Lấy số thứ tự từ mã giỏ hàng cuối cùng và tăng lên 1
                    int lastGioHangNumber = int.Parse(lastGioHang.MaGioHang.Replace("GH", ""));
                    int nextGioHangNumber = lastGioHangNumber + 1;
                    newMaGioHang = "GH" + nextGioHangNumber.ToString().PadLeft(3, '0');
                }

                x.MaGioHang = newMaGioHang;
                x.ID = ID;
                db.GIOHANGs.Add(x);
                db.SaveChanges();
            }
            
            return View(db.CHITIETGIOHANGs.Where(p=>p.MaGioHang==x.MaGioHang).ToList());
        }

        [HttpPost]
        public ActionResult ThemSpVaoGioHang(int id)
        {
            if (Session["username"] == null)
            {
                return Json(new { success = false, message = "Bạn cần đăng nhập trước!" }, JsonRequestBehavior.AllowGet);
            }
            int ID = (int)Session["username"];
            GIOHANG x = db.GIOHANGs.Where(p => p.ID == ID).FirstOrDefault();
            if (x == null)
            {
                x = new GIOHANG();
                // Lấy mã giỏ hàng cuối cùng từ cơ sở dữ liệu
                var lastGioHang = db.GIOHANGs.OrderByDescending(p => p.MaGioHang).FirstOrDefault();
                string newMaGioHang;
                if (lastGioHang == null)
                {
                    // Nếu không có giỏ hàng nào trong cơ sở dữ liệu
                    newMaGioHang = "GH001";
                }
                else
                {
                    // Lấy số thứ tự từ mã giỏ hàng cuối cùng và tăng lên 1
                    int lastGioHangNumber = int.Parse(lastGioHang.MaGioHang.Replace("GH", ""));
                    int nextGioHangNumber = lastGioHangNumber + 1;
                    newMaGioHang = "GH" + nextGioHangNumber.ToString().PadLeft(3, '0');
                }

                x.MaGioHang = newMaGioHang;
                x.ID = ID;
                db.GIOHANGs.Add(x);
                db.SaveChanges();
            }

            var SpTrongGioHang = x.CHITIETGIOHANGs.FirstOrDefault(i => i.MaSanPham == id);
            if (SpTrongGioHang == null)
            {
                var ThemVaoGioHang = new CHITIETGIOHANG
                {
                    MaGioHang = x.MaGioHang,
                    MaSanPham = id,
                    SoLuong = 1
                };
                db.CHITIETGIOHANGs.Add(ThemVaoGioHang);
            }
            else
            {
                SpTrongGioHang.SoLuong++;
            }

            db.SaveChanges();
            return Json(new { success = true, message = "Sản phẩm đã được thêm vào giỏ hàng!" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateQuantity(int productId, int quantity)
        {
            if (Session["username"] == null)
            {
                return Json(new { success = false, message = "Bạn cần đăng nhập trước!" }, JsonRequestBehavior.AllowGet);
            }
            // Lấy thông tin giỏ hàng của người dùng
            int userID = (int)Session["username"];
            GIOHANG cart = db.GIOHANGs.FirstOrDefault(c => c.ID == userID);
            if (cart != null)
            {
                // Lấy chi tiết giỏ hàng của sản phẩm cần cập nhật
                CHITIETGIOHANG cartItem = cart.CHITIETGIOHANGs.FirstOrDefault(item => item.MaSanPham == productId);
                if (cartItem != null)
                {
                    cartItem.SoLuong = quantity;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("XemGioHang");
        }

        // POST: XemGioHang/DeleteFromCart
        [HttpPost]
        public ActionResult DeleteFromCart(int productId)
        {
            // Lấy thông tin giỏ hàng của người dùng
            int userID = (int)Session["username"];
            GIOHANG cart = db.GIOHANGs.FirstOrDefault(c => c.ID == userID);
            if (cart != null)
            {
                // Xóa sản phẩm khỏi giỏ hàng
                CHITIETGIOHANG cartItem = cart.CHITIETGIOHANGs.FirstOrDefault(item => item.MaSanPham == productId);
                if (cartItem != null)
                {
                    db.CHITIETGIOHANGs.Remove(cartItem);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("XemGioHang");
        }
    }
}