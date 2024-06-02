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
    public class XemSanPhamTheoDanhMucController : Controller
    {
        private Model1 db = new Model1();

        // Action để hiển thị sản phẩm theo danh mục
        public ActionResult DsSanPhamByMaDanhMuc(int id)
        {
            // Lấy danh sách sản phẩm thuộc danh mục có id tương ứng
            var danhMuc = db.DANHMUCs.Find(id);
            if (danhMuc == null)
            {
                return HttpNotFound();
            }

            var sanPhamTheoDanhMuc = db.SANPHAMs.Where(sp => sp.MaDanhMuc == id).ToList();
            if (sanPhamTheoDanhMuc == null) ViewBag.message = "Không có dữ liệu về sản phẩm nào";
            ViewBag.TenDanhMuc = danhMuc.TenDanhMuc;
            return View(sanPhamTheoDanhMuc);
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