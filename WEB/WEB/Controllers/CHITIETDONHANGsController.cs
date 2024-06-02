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
    public class CHITIETDONHANGsController : Controller
    {
        private Model1 db = new Model1();

        // GET: CHITIETDONHANGs
        public ActionResult Index()
        {
            var cHITIETDONHANGs = db.CHITIETDONHANGs.Include(c => c.DONHANG).Include(c => c.SANPHAM);
            return View(cHITIETDONHANGs.ToList());
        }

        // GET: CHITIETDONHANGs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETDONHANG cHITIETDONHANG = db.CHITIETDONHANGs.Find(id);
            if (cHITIETDONHANG == null)
            {
                return HttpNotFound();
            }
            return View(cHITIETDONHANG);
        }

        // GET: CHITIETDONHANGs/Create
        public ActionResult Create()
        {
            ViewBag.MaDonHang = new SelectList(db.DONHANGs, "MaDonHang", "DiaChiGiao");
            ViewBag.MaSanPham = new SelectList(db.SANPHAMs, "MaSanPham", "TenSanPham");
            return View();
        }

        // POST: CHITIETDONHANGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSanPham,MaDonHang,SoLuongMua,GiaMua")] CHITIETDONHANG cHITIETDONHANG)
        {
            if (ModelState.IsValid)
            {
                db.CHITIETDONHANGs.Add(cHITIETDONHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDonHang = new SelectList(db.DONHANGs, "MaDonHang", "DiaChiGiao", cHITIETDONHANG.MaDonHang);
            ViewBag.MaSanPham = new SelectList(db.SANPHAMs, "MaSanPham", "TenSanPham", cHITIETDONHANG.MaSanPham);
            return View(cHITIETDONHANG);
        }

        // GET: CHITIETDONHANGs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETDONHANG cHITIETDONHANG = db.CHITIETDONHANGs.Find(id);
            if (cHITIETDONHANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDonHang = new SelectList(db.DONHANGs, "MaDonHang", "DiaChiGiao", cHITIETDONHANG.MaDonHang);
            ViewBag.MaSanPham = new SelectList(db.SANPHAMs, "MaSanPham", "TenSanPham", cHITIETDONHANG.MaSanPham);
            return View(cHITIETDONHANG);
        }

        // POST: CHITIETDONHANGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSanPham,MaDonHang,SoLuongMua,GiaMua")] CHITIETDONHANG cHITIETDONHANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHITIETDONHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDonHang = new SelectList(db.DONHANGs, "MaDonHang", "DiaChiGiao", cHITIETDONHANG.MaDonHang);
            ViewBag.MaSanPham = new SelectList(db.SANPHAMs, "MaSanPham", "TenSanPham", cHITIETDONHANG.MaSanPham);
            return View(cHITIETDONHANG);
        }

        // GET: CHITIETDONHANGs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETDONHANG cHITIETDONHANG = db.CHITIETDONHANGs.Find(id);
            if (cHITIETDONHANG == null)
            {
                return HttpNotFound();
            }
            return View(cHITIETDONHANG);
        }

        // POST: CHITIETDONHANGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CHITIETDONHANG cHITIETDONHANG = db.CHITIETDONHANGs.Find(id);
            db.CHITIETDONHANGs.Remove(cHITIETDONHANG);
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
