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
    public class GIAMGIAsController : Controller
    {
        private Model1 db = new Model1();

        // GET: GIAMGIAs
        public ActionResult Index()
        {
            return View(db.GIAMGIAs.ToList());
        }

        // GET: GIAMGIAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GIAMGIA gIAMGIA = db.GIAMGIAs.Find(id);
            if (gIAMGIA == null)
            {
                return HttpNotFound();
            }
            return View(gIAMGIA);
        }

        // GET: GIAMGIAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GIAMGIAs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaGiamGia,MoTa,TenGiamGia,NgayBatDau,NgayKetThuc,SoLuong")] GIAMGIA gIAMGIA)
        {
            if (ModelState.IsValid)
            {
                db.GIAMGIAs.Add(gIAMGIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gIAMGIA);
        }

        // GET: GIAMGIAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GIAMGIA gIAMGIA = db.GIAMGIAs.Find(id);
            if (gIAMGIA == null)
            {
                return HttpNotFound();
            }
            return View(gIAMGIA);
        }

        // POST: GIAMGIAs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaGiamGia,MoTa,TenGiamGia,NgayBatDau,NgayKetThuc,SoLuong")] GIAMGIA gIAMGIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gIAMGIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gIAMGIA);
        }

        // GET: GIAMGIAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GIAMGIA gIAMGIA = db.GIAMGIAs.Find(id);
            if (gIAMGIA == null)
            {
                return HttpNotFound();
            }
            return View(gIAMGIA);
        }

        // POST: GIAMGIAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GIAMGIA gIAMGIA = db.GIAMGIAs.Find(id);
            db.GIAMGIAs.Remove(gIAMGIA);
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
