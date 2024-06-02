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
    public class DONHANGsController : Controller
    {
        private Model1 db = new Model1();

        // GET: DONHANGs
        public ActionResult Index()
        {
            var dONHANGs = db.DONHANGs.Include(d => d.GIAMGIA).Include(d => d.HINHTHUCTHANHTOAN).Include(d => d.HINHTHUCVANCHUYEN).Include(d => d.TAIKHOAN);
            return View(dONHANGs.ToList());
        }

        // GET: DONHANGs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONHANG dONHANG = db.DONHANGs.Find(id);
            if (dONHANG == null)
            {
                return HttpNotFound();
            }
            return View(dONHANG);
        }

        // GET: DONHANGs/Create
        public ActionResult Create()
        {
            ViewBag.MaGiamGia = new SelectList(db.GIAMGIAs, "MaGiamGia", "MoTa");
            ViewBag.MaHinhThucThanhToan = new SelectList(db.HINHTHUCTHANHTOANs, "MaHinhThucThanhToan", "TenHinhThucThanhToan");
            ViewBag.MaHinhThucVanChuyen = new SelectList(db.HINHTHUCVANCHUYENs, "MaHinhThucVanChuyen", "TenHinhThucVanChuyen");
            ViewBag.ID = new SelectList(db.TAIKHOANs, "ID", "Ho");
            return View();
        }

        // POST: DONHANGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDonHang,NgayDatHang,DiaChiGiao,GhiChu,TinhTrangThanhToan,TinhTrangGiaoHang,ID,MaHinhThucThanhToan,MaHinhThucVanChuyen,MaGiamGia")] DONHANG dONHANG)
        {
            if (ModelState.IsValid)
            {
                db.DONHANGs.Add(dONHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaGiamGia = new SelectList(db.GIAMGIAs, "MaGiamGia", "MoTa", dONHANG.MaGiamGia);
            ViewBag.MaHinhThucThanhToan = new SelectList(db.HINHTHUCTHANHTOANs, "MaHinhThucThanhToan", "TenHinhThucThanhToan", dONHANG.MaHinhThucThanhToan);
            ViewBag.MaHinhThucVanChuyen = new SelectList(db.HINHTHUCVANCHUYENs, "MaHinhThucVanChuyen", "TenHinhThucVanChuyen", dONHANG.MaHinhThucVanChuyen);
            ViewBag.ID = new SelectList(db.TAIKHOANs, "ID", "Ho", dONHANG.ID);
            return View(dONHANG);
        }

        // GET: DONHANGs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONHANG dONHANG = db.DONHANGs.Find(id);
            if (dONHANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaGiamGia = new SelectList(db.GIAMGIAs, "MaGiamGia", "MoTa", dONHANG.MaGiamGia);
            ViewBag.MaHinhThucThanhToan = new SelectList(db.HINHTHUCTHANHTOANs, "MaHinhThucThanhToan", "TenHinhThucThanhToan", dONHANG.MaHinhThucThanhToan);
            ViewBag.MaHinhThucVanChuyen = new SelectList(db.HINHTHUCVANCHUYENs, "MaHinhThucVanChuyen", "TenHinhThucVanChuyen", dONHANG.MaHinhThucVanChuyen);
            ViewBag.ID = new SelectList(db.TAIKHOANs, "ID", "Ho", dONHANG.ID);
            return View(dONHANG);
        }

        // POST: DONHANGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDonHang,NgayDatHang,DiaChiGiao,GhiChu,TinhTrangThanhToan,TinhTrangGiaoHang,ID,MaHinhThucThanhToan,MaHinhThucVanChuyen,MaGiamGia")] DONHANG dONHANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dONHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaGiamGia = new SelectList(db.GIAMGIAs, "MaGiamGia", "MoTa", dONHANG.MaGiamGia);
            ViewBag.MaHinhThucThanhToan = new SelectList(db.HINHTHUCTHANHTOANs, "MaHinhThucThanhToan", "TenHinhThucThanhToan", dONHANG.MaHinhThucThanhToan);
            ViewBag.MaHinhThucVanChuyen = new SelectList(db.HINHTHUCVANCHUYENs, "MaHinhThucVanChuyen", "TenHinhThucVanChuyen", dONHANG.MaHinhThucVanChuyen);
            ViewBag.ID = new SelectList(db.TAIKHOANs, "ID", "Ho", dONHANG.ID);
            return View(dONHANG);
        }

        // GET: DONHANGs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONHANG dONHANG = db.DONHANGs.Find(id);
            if (dONHANG == null)
            {
                return HttpNotFound();
            }
            return View(dONHANG);
        }

        // POST: DONHANGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DONHANG dONHANG = db.DONHANGs.Find(id);
            db.DONHANGs.Remove(dONHANG);
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
