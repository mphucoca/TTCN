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
    public class TINTUCsController : Controller
    {
        private Model1 db = new Model1();

        // GET: TINTUCs
        public ActionResult Index()
        {
            var tINTUCs = db.TINTUCs.Include(t => t.NHANVIEN);
            return View(tINTUCs.ToList());
        }

        // GET: TINTUCs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TINTUC tINTUC = db.TINTUCs.Find(id);
            if (tINTUC == null)
            {
                return HttpNotFound();
            }
            return View(tINTUC);
        }

        // GET: TINTUCs/Create
        public ActionResult Create()
        {
            ViewBag.MaNhanVien = new SelectList(db.NHANVIENs, "MaNhanVien", "HoTen");
            return View();
        }

        // POST: TINTUCs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTinTuc,TieuDe,NoiDung,HinhAnh,ThoiGian,MaNhanVien")] TINTUC tINTUC)
        {
            if (ModelState.IsValid)
            {
                db.TINTUCs.Add(tINTUC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNhanVien = new SelectList(db.NHANVIENs, "MaNhanVien", "HoTen", tINTUC.MaNhanVien);
            return View(tINTUC);
        }

        // GET: TINTUCs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TINTUC tINTUC = db.TINTUCs.Find(id);
            if (tINTUC == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNhanVien = new SelectList(db.NHANVIENs, "MaNhanVien", "HoTen", tINTUC.MaNhanVien);
            return View(tINTUC);
        }

        // POST: TINTUCs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTinTuc,TieuDe,NoiDung,HinhAnh,ThoiGian,MaNhanVien")] TINTUC tINTUC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tINTUC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNhanVien = new SelectList(db.NHANVIENs, "MaNhanVien", "HoTen", tINTUC.MaNhanVien);
            return View(tINTUC);
        }

        // GET: TINTUCs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TINTUC tINTUC = db.TINTUCs.Find(id);
            if (tINTUC == null)
            {
                return HttpNotFound();
            }
            return View(tINTUC);
        }

        // POST: TINTUCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TINTUC tINTUC = db.TINTUCs.Find(id);
            db.TINTUCs.Remove(tINTUC);
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
