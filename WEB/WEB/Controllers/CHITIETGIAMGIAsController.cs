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
    public class CHITIETGIAMGIAsController : Controller
    {
        private Model1 db = new Model1();

        // GET: CHITIETGIAMGIAs
        public ActionResult Index()
        {
            var cHITIETGIAMGIAs = db.CHITIETGIAMGIAs.Include(c => c.GIAMGIA).Include(c => c.SANPHAM);
            return View(cHITIETGIAMGIAs.ToList());
        }

        // GET: CHITIETGIAMGIAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETGIAMGIA cHITIETGIAMGIA = db.CHITIETGIAMGIAs.Find(id);
            if (cHITIETGIAMGIA == null)
            {
                return HttpNotFound();
            }
            return View(cHITIETGIAMGIA);
        }

        // GET: CHITIETGIAMGIAs/Create
        public ActionResult Create()
        {
            ViewBag.MaGiamGia = new SelectList(db.GIAMGIAs, "MaGiamGia", "MoTa");
            ViewBag.MaSanPham = new SelectList(db.SANPHAMs, "MaSanPham", "TenSanPham");
            return View();
        }

        // POST: CHITIETGIAMGIAs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSanPham,MaGiamGia,MucGiamGia,Giamua")] CHITIETGIAMGIA cHITIETGIAMGIA)
        {
            if (ModelState.IsValid)
            {
                db.CHITIETGIAMGIAs.Add(cHITIETGIAMGIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaGiamGia = new SelectList(db.GIAMGIAs, "MaGiamGia", "MoTa", cHITIETGIAMGIA.MaGiamGia);
            ViewBag.MaSanPham = new SelectList(db.SANPHAMs, "MaSanPham", "TenSanPham", cHITIETGIAMGIA.MaSanPham);
            return View(cHITIETGIAMGIA);
        }

        // GET: CHITIETGIAMGIAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETGIAMGIA cHITIETGIAMGIA = db.CHITIETGIAMGIAs.Find(id);
            if (cHITIETGIAMGIA == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaGiamGia = new SelectList(db.GIAMGIAs, "MaGiamGia", "MoTa", cHITIETGIAMGIA.MaGiamGia);
            ViewBag.MaSanPham = new SelectList(db.SANPHAMs, "MaSanPham", "TenSanPham", cHITIETGIAMGIA.MaSanPham);
            return View(cHITIETGIAMGIA);
        }

        // POST: CHITIETGIAMGIAs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSanPham,MaGiamGia,MucGiamGia,Giamua")] CHITIETGIAMGIA cHITIETGIAMGIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHITIETGIAMGIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaGiamGia = new SelectList(db.GIAMGIAs, "MaGiamGia", "MoTa", cHITIETGIAMGIA.MaGiamGia);
            ViewBag.MaSanPham = new SelectList(db.SANPHAMs, "MaSanPham", "TenSanPham", cHITIETGIAMGIA.MaSanPham);
            return View(cHITIETGIAMGIA);
        }

        // GET: CHITIETGIAMGIAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETGIAMGIA cHITIETGIAMGIA = db.CHITIETGIAMGIAs.Find(id);
            if (cHITIETGIAMGIA == null)
            {
                return HttpNotFound();
            }
            return View(cHITIETGIAMGIA);
        }

        // POST: CHITIETGIAMGIAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CHITIETGIAMGIA cHITIETGIAMGIA = db.CHITIETGIAMGIAs.Find(id);
            db.CHITIETGIAMGIAs.Remove(cHITIETGIAMGIA);
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
