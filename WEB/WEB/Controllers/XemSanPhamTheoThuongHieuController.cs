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
    public class XemSanPhamTheoThuongHieuController : Controller
    {
        private Model1 db = new Model1();

        // Action để hiển thị sản phẩm theo thương hiệu
        public ActionResult DsSanPhamByMaThuongHieu(int id)
        {
            // Lấy danh sách sản phẩm thuộc thương hiệu có id tương ứng
            var thuongHieu = db.THUONGHIEUx.Find(id);
            if (thuongHieu == null)
            {
                return HttpNotFound();
            }

            var sanPhamTheoThuongHieu = db.SANPHAMs.Where(sp => sp.MaThuongHieu == id).ToList();
            if (sanPhamTheoThuongHieu == null) ViewBag.message = "Không có dữ liệu về sản phẩm nào";
            ViewBag.TenThuongHieu = thuongHieu.TenThuongHieu;
            return View(sanPhamTheoThuongHieu);
        }
        public ActionResult XemChiTietSanPham(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(sANPHAM);
        }
    }
}