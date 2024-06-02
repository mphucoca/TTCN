using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WEB.Models;
using System.IO;

namespace WEB.Controllers
{
    public class QuanLyTinTucController : Controller
    {
        private Model1 db = new Model1();
        public ActionResult QuanLyTinTuc()
        {
            if (Session["Phanquyen"] != null && string.Equals((string)Session["Phanquyen"], "admin", StringComparison.OrdinalIgnoreCase))
            {
                return View(db.TINTUCs.ToList());
            }
            else
            {
                return RedirectToAction("DangNhap", "DangNhap");
            }

        }

        public ActionResult TaoTinTuc()
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            ViewBag.MaNhanVien = new SelectList(db.NHANVIENs, "MaNhanVien", "HoTen");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TaoTinTuc([Bind(Include = "TieuDe,NoiDung,HinhAnh,ThoiGian,MaNhanVien")] TINTUC tintuc, HttpPostedFileBase HinhAnh)
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (ModelState.IsValid)
            {
                if (HinhAnh != null && HinhAnh.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(HinhAnh.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/SanPhamImage/"), fileName);
                    HinhAnh.SaveAs(path);
                    tintuc.HinhAnh = fileName; // Lưu tên tệp hình ảnh vào thuộc tính HinhAnh
                }
                var existingIds = db.TINTUCs.Select(p => p.MaTinTuc).ToList();
                int newId = 1;

                // Tìm giá trị nhỏ nhất không có trong danh sách mã sản phẩm hiện có
                while (existingIds.Contains(newId))
                {
                    newId++;
                }
                tintuc.MaTinTuc = newId;
                db.TINTUCs.Add(tintuc);
                db.SaveChanges();
                return RedirectToAction("QuanLyTinTuc");
            }
            ViewBag.MaNhanVien = new SelectList(db.NHANVIENs, "MaNhanVien", "HoTen");
            return View(tintuc);
        }

        public ActionResult SuaTinTuc(int? id)
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TINTUC tintuc = db.TINTUCs.Find(id);
            if (tintuc == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNhanVien = new SelectList(db.NHANVIENs, "MaNhanVien", "HoTen");

            return View(tintuc);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaTinTuc([Bind(Include = "MaTinTuc,TieuDe,NoiDung,HinhAnh,ThoiGian,MaNhanVien")] TINTUC tintuc, HttpPostedFileBase HinhAnh, string CurrentHinhAnh)
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (ModelState.IsValid)
            {
                if (HinhAnh != null && HinhAnh.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(HinhAnh.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/SanPhamImage/"), fileName);
                    HinhAnh.SaveAs(path);
                    tintuc.HinhAnh = fileName; // Lưu tên tệp hình ảnh vào thuộc tính HinhAnh
                }
                else
                {
                    tintuc.HinhAnh = CurrentHinhAnh; // Giữ lại hình ảnh hiện tại nếu không chọn hình ảnh mới
                }

                db.Entry(tintuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("QuanLyTinTuc");
            }
            ViewBag.MaNhanVien = new SelectList(db.NHANVIENs, "MaNhanVien", "HoTen");

            return View(tintuc);
        }
        public ActionResult XoaTinTuc(int? id)
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TINTUC tintuc = db.TINTUCs.Find(id);

            if (tintuc == null)
            {
                return HttpNotFound();
            }
            return View(tintuc);
        }

        [HttpPost, ActionName("XoaTinTuc")]
        [ValidateAntiForgeryToken]
        public ActionResult XoaTinTucConfirmed(int id)
        {
            TINTUC tintuc = db.TINTUCs.Find(id);

            db.TINTUCs.Remove(tintuc);
            db.SaveChanges();
            return RedirectToAction("QuanLyTinTuc");
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