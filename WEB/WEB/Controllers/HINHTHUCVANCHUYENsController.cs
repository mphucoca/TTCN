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
    public class HINHTHUCVANCHUYENsController : Controller
    {
        private Model1 db = new Model1();

        // GET: HINHTHUCVANCHUYENs
        public ActionResult Index()
        {
            return View(db.HINHTHUCVANCHUYENs.ToList());
        }

        // GET: HINHTHUCVANCHUYENs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HINHTHUCVANCHUYEN hINHTHUCVANCHUYEN = db.HINHTHUCVANCHUYENs.Find(id);
            if (hINHTHUCVANCHUYEN == null)
            {
                return HttpNotFound();
            }
            return View(hINHTHUCVANCHUYEN);
        }

        // GET: HINHTHUCVANCHUYENs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HINHTHUCVANCHUYENs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHinhThucVanChuyen,TenHinhThucVanChuyen,MoTa")] HINHTHUCVANCHUYEN hINHTHUCVANCHUYEN)
        {
            if (ModelState.IsValid)
            {
                db.HINHTHUCVANCHUYENs.Add(hINHTHUCVANCHUYEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hINHTHUCVANCHUYEN);
        }

        // GET: HINHTHUCVANCHUYENs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HINHTHUCVANCHUYEN hINHTHUCVANCHUYEN = db.HINHTHUCVANCHUYENs.Find(id);
            if (hINHTHUCVANCHUYEN == null)
            {
                return HttpNotFound();
            }
            return View(hINHTHUCVANCHUYEN);
        }

        // POST: HINHTHUCVANCHUYENs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHinhThucVanChuyen,TenHinhThucVanChuyen,MoTa")] HINHTHUCVANCHUYEN hINHTHUCVANCHUYEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hINHTHUCVANCHUYEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hINHTHUCVANCHUYEN);
        }

        // GET: HINHTHUCVANCHUYENs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HINHTHUCVANCHUYEN hINHTHUCVANCHUYEN = db.HINHTHUCVANCHUYENs.Find(id);
            if (hINHTHUCVANCHUYEN == null)
            {
                return HttpNotFound();
            }
            return View(hINHTHUCVANCHUYEN);
        }

        // POST: HINHTHUCVANCHUYENs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HINHTHUCVANCHUYEN hINHTHUCVANCHUYEN = db.HINHTHUCVANCHUYENs.Find(id);
            db.HINHTHUCVANCHUYENs.Remove(hINHTHUCVANCHUYEN);
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
