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
    public class KHOHANGsController : Controller
    {
        private Model1 db = new Model1();

        // GET: KHOHANGs
        public ActionResult Index()
        {
            var kHOHANGs = db.KHOHANGs.Include(k => k.CUAHANG).Include(k => k.SANPHAM);
            return View(kHOHANGs.ToList());
        }

        // GET: KHOHANGs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHOHANG kHOHANG = db.KHOHANGs.Find(id);
            if (kHOHANG == null)
            {
                return HttpNotFound();
            }
            return View(kHOHANG);
        }

        // GET: KHOHANGs/Create
        public ActionResult Create()
        {
            ViewBag.MaCuaHang = new SelectList(db.CUAHANGs, "MaCuaHang", "TenCuaHang");
            ViewBag.MaSanPham = new SelectList(db.SANPHAMs, "MaSanPham", "TenSanPham");
            return View();
        }

        // POST: KHOHANGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCuaHang,MaSanPham,SoLuong")] KHOHANG kHOHANG)
        {
            if (ModelState.IsValid)
            {
                db.KHOHANGs.Add(kHOHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaCuaHang = new SelectList(db.CUAHANGs, "MaCuaHang", "TenCuaHang", kHOHANG.MaCuaHang);
            ViewBag.MaSanPham = new SelectList(db.SANPHAMs, "MaSanPham", "TenSanPham", kHOHANG.MaSanPham);
            return View(kHOHANG);
        }

        // GET: KHOHANGs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHOHANG kHOHANG = db.KHOHANGs.Find(id);
            if (kHOHANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaCuaHang = new SelectList(db.CUAHANGs, "MaCuaHang", "TenCuaHang", kHOHANG.MaCuaHang);
            ViewBag.MaSanPham = new SelectList(db.SANPHAMs, "MaSanPham", "TenSanPham", kHOHANG.MaSanPham);
            return View(kHOHANG);
        }

        // POST: KHOHANGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCuaHang,MaSanPham,SoLuong")] KHOHANG kHOHANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kHOHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaCuaHang = new SelectList(db.CUAHANGs, "MaCuaHang", "TenCuaHang", kHOHANG.MaCuaHang);
            ViewBag.MaSanPham = new SelectList(db.SANPHAMs, "MaSanPham", "TenSanPham", kHOHANG.MaSanPham);
            return View(kHOHANG);
        }

        // GET: KHOHANGs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHOHANG kHOHANG = db.KHOHANGs.Find(id);
            if (kHOHANG == null)
            {
                return HttpNotFound();
            }
            return View(kHOHANG);
        }

        // POST: KHOHANGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KHOHANG kHOHANG = db.KHOHANGs.Find(id);
            db.KHOHANGs.Remove(kHOHANG);
            db.SaveChanges();
            return RedirectToAction("Index");
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
