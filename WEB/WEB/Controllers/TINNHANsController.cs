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
    public class TINNHANsController : Controller
    {
        private Model1 db = new Model1();

        // GET: TINNHANs
        public ActionResult Index()
        {
            var tINNHANs = db.TINNHANs.Include(t => t.CUAHANG);
            return View(tINNHANs.ToList());
        }

        // GET: TINNHANs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TINNHAN tINNHAN = db.TINNHANs.Find(id);
            if (tINNHAN == null)
            {
                return HttpNotFound();
            }
            return View(tINNHAN);
        }

        // GET: TINNHANs/Create
        public ActionResult Create()
        {
            ViewBag.MaCuaHang = new SelectList(db.CUAHANGs, "MaCuaHang", "TenCuaHang");
            return View();
        }

        // POST: TINNHANs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTinNhan,Hoten,Email,SDT,NoiDung,MaCuaHang")] TINNHAN tINNHAN)
        {
            if (ModelState.IsValid)
            {
                db.TINNHANs.Add(tINNHAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaCuaHang = new SelectList(db.CUAHANGs, "MaCuaHang", "TenCuaHang", tINNHAN.MaCuaHang);
            return View(tINNHAN);
        }

        // GET: TINNHANs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TINNHAN tINNHAN = db.TINNHANs.Find(id);
            if (tINNHAN == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaCuaHang = new SelectList(db.CUAHANGs, "MaCuaHang", "TenCuaHang", tINNHAN.MaCuaHang);
            return View(tINNHAN);
        }

        // POST: TINNHANs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTinNhan,Hoten,Email,SDT,NoiDung,MaCuaHang")] TINNHAN tINNHAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tINNHAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaCuaHang = new SelectList(db.CUAHANGs, "MaCuaHang", "TenCuaHang", tINNHAN.MaCuaHang);
            return View(tINNHAN);
        }

        // GET: TINNHANs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TINNHAN tINNHAN = db.TINNHANs.Find(id);
            if (tINNHAN == null)
            {
                return HttpNotFound();
            }
            return View(tINNHAN);
        }

        // POST: TINNHANs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TINNHAN tINNHAN = db.TINNHANs.Find(id);
            db.TINNHANs.Remove(tINNHAN);
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
