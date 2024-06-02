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
    public class CUAHANGsController : Controller
    {
        private Model1 db = new Model1();

        // GET: CUAHANGs
        public ActionResult Index()
        {
            return View(db.CUAHANGs.ToList());
        }

        // GET: CUAHANGs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUAHANG cUAHANG = db.CUAHANGs.Find(id);
            if (cUAHANG == null)
            {
                return HttpNotFound();
            }
            return View(cUAHANG);
        }

        // GET: CUAHANGs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CUAHANGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCuaHang,TenCuaHang,DiaChi,SoDienThoai")] CUAHANG cUAHANG)
        {
            if (ModelState.IsValid)
            {
                db.CUAHANGs.Add(cUAHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cUAHANG);
        }

        // GET: CUAHANGs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUAHANG cUAHANG = db.CUAHANGs.Find(id);
            if (cUAHANG == null)
            {
                return HttpNotFound();
            }
            return View(cUAHANG);
        }

        // POST: CUAHANGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCuaHang,TenCuaHang,DiaChi,SoDienThoai")] CUAHANG cUAHANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cUAHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cUAHANG);
        }

        // GET: CUAHANGs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUAHANG cUAHANG = db.CUAHANGs.Find(id);
            if (cUAHANG == null)
            {
                return HttpNotFound();
            }
            return View(cUAHANG);
        }

        // POST: CUAHANGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CUAHANG cUAHANG = db.CUAHANGs.Find(id);
            db.CUAHANGs.Remove(cUAHANG);
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
