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
    public class SANPHAMsController : Controller
    {
        private Model1 db = new Model1();

        // GET: SANPHAMs
        public ActionResult Index()
        {
            var sANPHAMs = db.SANPHAMs.Include(s => s.DANHMUC).Include(s => s.THUONGHIEU);
            return View(sANPHAMs.ToList());
        }

        // GET: SANPHAMs/Details/5
        public ActionResult Details(int? id)
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

        // GET: SANPHAMs/Create
        public ActionResult Create()
        {
            ViewBag.MaDanhMuc = new SelectList(db.DANHMUCs, "MaDanhMuc", "TenDanhMuc");
            ViewBag.MaThuongHieu = new SelectList(db.THUONGHIEUx, "MaThuongHieu", "TenThuongHieu");
            return View();
        }

        // POST: SANPHAMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSanPham,TenSanPham,HinhAnh,GiaTien,DungTich,MoTa,MaDanhMuc,MaThuongHieu")] SANPHAM sANPHAM)
        {
            if (ModelState.IsValid)
            {
                db.SANPHAMs.Add(sANPHAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDanhMuc = new SelectList(db.DANHMUCs, "MaDanhMuc", "TenDanhMuc", sANPHAM.MaDanhMuc);
            ViewBag.MaThuongHieu = new SelectList(db.THUONGHIEUx, "MaThuongHieu", "TenThuongHieu", sANPHAM.MaThuongHieu);
            return View(sANPHAM);
        }

        // GET: SANPHAMs/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.MaDanhMuc = new SelectList(db.DANHMUCs, "MaDanhMuc", "TenDanhMuc", sANPHAM.MaDanhMuc);
            ViewBag.MaThuongHieu = new SelectList(db.THUONGHIEUx, "MaThuongHieu", "TenThuongHieu", sANPHAM.MaThuongHieu);
            return View(sANPHAM);
        }

        // POST: SANPHAMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSanPham,TenSanPham,HinhAnh,GiaTien,DungTich,MoTa,MaDanhMuc,MaThuongHieu")] SANPHAM sANPHAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sANPHAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDanhMuc = new SelectList(db.DANHMUCs, "MaDanhMuc", "TenDanhMuc", sANPHAM.MaDanhMuc);
            ViewBag.MaThuongHieu = new SelectList(db.THUONGHIEUx, "MaThuongHieu", "TenThuongHieu", sANPHAM.MaThuongHieu);
            return View(sANPHAM);
        }

        // GET: SANPHAMs/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: SANPHAMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            db.SANPHAMs.Remove(sANPHAM);
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
