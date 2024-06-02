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
    public class THUONGHIEUxController : Controller
    {
        private Model1 db = new Model1();

        // GET: THUONGHIEUx
        public ActionResult Index()
        {
            return View(db.THUONGHIEUx.ToList());
        }

        // GET: THUONGHIEUx/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THUONGHIEU tHUONGHIEU = db.THUONGHIEUx.Find(id);
            if (tHUONGHIEU == null)
            {
                return HttpNotFound();
            }
            return View(tHUONGHIEU);
        }

        // GET: THUONGHIEUx/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: THUONGHIEUx/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaThuongHieu,TenThuongHieu")] THUONGHIEU tHUONGHIEU)
        {
            if (ModelState.IsValid)
            {
                db.THUONGHIEUx.Add(tHUONGHIEU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tHUONGHIEU);
        }

        // GET: THUONGHIEUx/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THUONGHIEU tHUONGHIEU = db.THUONGHIEUx.Find(id);
            if (tHUONGHIEU == null)
            {
                return HttpNotFound();
            }
            return View(tHUONGHIEU);
        }

        // POST: THUONGHIEUx/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaThuongHieu,TenThuongHieu")] THUONGHIEU tHUONGHIEU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tHUONGHIEU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tHUONGHIEU);
        }

        // GET: THUONGHIEUx/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THUONGHIEU tHUONGHIEU = db.THUONGHIEUx.Find(id);
            if (tHUONGHIEU == null)
            {
                return HttpNotFound();
            }
            return View(tHUONGHIEU);
        }

        // POST: THUONGHIEUx/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            THUONGHIEU tHUONGHIEU = db.THUONGHIEUx.Find(id);
            db.THUONGHIEUx.Remove(tHUONGHIEU);
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
