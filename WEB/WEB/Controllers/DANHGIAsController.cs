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
    public class DANHGIAsController : Controller
    {
        private Model1 db = new Model1();

        // GET: DANHGIAs
        public ActionResult Index()
        {
            var dANHGIAs = db.DANHGIAs.Include(d => d.SANPHAM);
            return View(dANHGIAs.ToList());
        }

        // GET: DANHGIAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANHGIA dANHGIA = db.DANHGIAs.Find(id);
            if (dANHGIA == null)
            {
                return HttpNotFound();
            }
            return View(dANHGIA);
        }

        // GET: DANHGIAs/Create
        public ActionResult Create()
        {
            ViewBag.MaSanPham = new SelectList(db.SANPHAMs, "MaSanPham", "TenSanPham");
            return View();
        }

        // POST: DANHGIAs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDanhGiaSanPham,HoTen,NoiDungDanhGia,Email,MaSanPham,ThoiGian,HinhAnh")] DANHGIA dANHGIA)
        {
            if (ModelState.IsValid)
            {
                db.DANHGIAs.Add(dANHGIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaSanPham = new SelectList(db.SANPHAMs, "MaSanPham", "TenSanPham", dANHGIA.MaSanPham);
            return View(dANHGIA);
        }

        // GET: DANHGIAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANHGIA dANHGIA = db.DANHGIAs.Find(id);
            if (dANHGIA == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaSanPham = new SelectList(db.SANPHAMs, "MaSanPham", "TenSanPham", dANHGIA.MaSanPham);
            return View(dANHGIA);
        }

        // POST: DANHGIAs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDanhGiaSanPham,HoTen,NoiDungDanhGia,Email,MaSanPham,ThoiGian,HinhAnh")] DANHGIA dANHGIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dANHGIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaSanPham = new SelectList(db.SANPHAMs, "MaSanPham", "TenSanPham", dANHGIA.MaSanPham);
            return View(dANHGIA);
        }

        // GET: DANHGIAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANHGIA dANHGIA = db.DANHGIAs.Find(id);
            if (dANHGIA == null)
            {
                return HttpNotFound();
            }
            return View(dANHGIA);
        }

        // POST: DANHGIAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DANHGIA dANHGIA = db.DANHGIAs.Find(id);
            db.DANHGIAs.Remove(dANHGIA);
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
