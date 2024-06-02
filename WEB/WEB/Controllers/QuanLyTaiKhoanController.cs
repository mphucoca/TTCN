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
    public class QuanLyTaiKhoanController : Controller
    {
        private Model1 db = new Model1();
        public ActionResult QuanLyTaiKhoan()
        {
            if (Session["Phanquyen"] != null && string.Equals((string)Session["Phanquyen"], "admin", StringComparison.OrdinalIgnoreCase))
            {
                return View(db.TAIKHOANs.ToList());
            }
            else { return RedirectToAction("DangNhap", "DangNhap"); 
            }
           
        }
        public ActionResult TaoTaiKhoan()
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TaoTaiKhoan([Bind(Include = "Ho,Ten,Email,SDT,MatKhau,PhanQuyen")] TAIKHOAN tAIKHOAN)
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (ModelState.IsValid)
            {
                var existingIds = db.TAIKHOANs.Select(p => p.ID).ToList();
                int newId = 1;

                // Tìm giá trị nhỏ nhất không có trong danh sách mã sản phẩm hiện có
                while (existingIds.Contains(newId))
                {
                    newId++;
                }
                tAIKHOAN.ID = newId;
                db.TAIKHOANs.Add(tAIKHOAN);
                db.SaveChanges();
                return RedirectToAction("QuanLyTaiKhoan");
            }

            return View(tAIKHOAN);
        }
        public ActionResult ChinhSuaTaiKhoan(int? id)
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAIKHOAN tAIKHOAN = db.TAIKHOANs.Find(id);
            if (tAIKHOAN == null)
            {
                return HttpNotFound();
            }
            return View(tAIKHOAN);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChinhSuaTaiKhoan([Bind(Include = "ID,Ho,Ten,Email,SDT,MatKhau,PhanQuyen")] TAIKHOAN tAIKHOAN)
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (ModelState.IsValid)
            {
                db.Entry(tAIKHOAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("QuanLyTaiKhoan");
            }
            return View(tAIKHOAN);
        }
        public ActionResult XoaTaiKhoan(int? id)
        {
            if ((String)Session["Phanquyen"] != "admin")
            {

                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAIKHOAN tAIKHOAN = db.TAIKHOANs.Find(id);
            if (tAIKHOAN == null)
            {
                return HttpNotFound();
            }
            return View(tAIKHOAN);
        }

        [HttpPost, ActionName("XoaTaiKhoan")]
        [ValidateAntiForgeryToken]
        public ActionResult XoaTaiKhoanConfirmed(int id)
        {
            TAIKHOAN tAIKHOAN = db.TAIKHOANs.Find(id);
            db.TAIKHOANs.Remove(tAIKHOAN);
            db.SaveChanges();
            return RedirectToAction("QuanLyTaiKhoan");
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