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
    public class CHITIETGIOHANGsController : Controller
    {
        private Model1 db = new Model1();

        // GET: CHITIETGIOHANGs
        public ActionResult Index()
        {
            var cHITIETGIOHANGs = db.CHITIETGIOHANGs.Include(c => c.GIOHANG).Include(c => c.SANPHAM);
            return View(cHITIETGIOHANGs.ToList());
        }

        // GET: CHITIETGIOHANGs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETGIOHANG cHITIETGIOHANG = db.CHITIETGIOHANGs.Find(id);
            if (cHITIETGIOHANG == null)
            {
                return HttpNotFound();
            }
            return View(cHITIETGIOHANG);
        }

        // GET: CHITIETGIOHANGs/Create
        public ActionResult Create()
        {
            ViewBag.MaGioHang = new SelectList(db.GIOHANGs, "MaGioHang", "MaGioHang");
            ViewBag.MaSanPham = new SelectList(db.SANPHAMs, "MaSanPham", "TenSanPham");
            return View();
        }

        // POST: CHITIETGIOHANGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSanPham,MaGioHang,SoLuong,Giaban")] CHITIETGIOHANG cHITIETGIOHANG)
        {
            if (ModelState.IsValid)
            {
                db.CHITIETGIOHANGs.Add(cHITIETGIOHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaGioHang = new SelectList(db.GIOHANGs, "MaGioHang", "MaGioHang", cHITIETGIOHANG.MaGioHang);
            ViewBag.MaSanPham = new SelectList(db.SANPHAMs, "MaSanPham", "TenSanPham", cHITIETGIOHANG.MaSanPham);
            return View(cHITIETGIOHANG);
        }

        // GET: CHITIETGIOHANGs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETGIOHANG cHITIETGIOHANG = db.CHITIETGIOHANGs.Find(id);
            if (cHITIETGIOHANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaGioHang = new SelectList(db.GIOHANGs, "MaGioHang", "MaGioHang", cHITIETGIOHANG.MaGioHang);
            ViewBag.MaSanPham = new SelectList(db.SANPHAMs, "MaSanPham", "TenSanPham", cHITIETGIOHANG.MaSanPham);
            return View(cHITIETGIOHANG);
        }

        // POST: CHITIETGIOHANGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSanPham,MaGioHang,SoLuong,Giaban")] CHITIETGIOHANG cHITIETGIOHANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHITIETGIOHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaGioHang = new SelectList(db.GIOHANGs, "MaGioHang", "MaGioHang", cHITIETGIOHANG.MaGioHang);
            ViewBag.MaSanPham = new SelectList(db.SANPHAMs, "MaSanPham", "TenSanPham", cHITIETGIOHANG.MaSanPham);
            return View(cHITIETGIOHANG);
        }

        // GET: CHITIETGIOHANGs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETGIOHANG cHITIETGIOHANG = db.CHITIETGIOHANGs.Find(id);
            if (cHITIETGIOHANG == null)
            {
                return HttpNotFound();
            }
            return View(cHITIETGIOHANG);
        }

        // POST: CHITIETGIOHANGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CHITIETGIOHANG cHITIETGIOHANG = db.CHITIETGIOHANGs.Find(id);
            db.CHITIETGIOHANGs.Remove(cHITIETGIOHANG);
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
