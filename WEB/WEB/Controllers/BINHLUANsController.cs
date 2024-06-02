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
    public class BINHLUANsController : Controller
    {
        private Model1 db = new Model1();

        // GET: BINHLUANs
        public ActionResult Index()
        {
            var bINHLUANs = db.BINHLUANs.Include(b => b.TINTUC);
            return View(bINHLUANs.ToList());
        }

        // GET: BINHLUANs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BINHLUAN bINHLUAN = db.BINHLUANs.Find(id);
            if (bINHLUAN == null)
            {
                return HttpNotFound();
            }
            return View(bINHLUAN);
        }

        // GET: BINHLUANs/Create
        public ActionResult Create()
        {
            ViewBag.MaTinTuc = new SelectList(db.TINTUCs, "MaTinTuc", "TieuDe");
            return View();
        }

        // POST: BINHLUANs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaBinhLuan,NoiDung,HoTen,Email,MaTinTuc")] BINHLUAN bINHLUAN)
        {
            if (ModelState.IsValid)
            {
                db.BINHLUANs.Add(bINHLUAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaTinTuc = new SelectList(db.TINTUCs, "MaTinTuc", "TieuDe", bINHLUAN.MaTinTuc);
            return View(bINHLUAN);
        }

        // GET: BINHLUANs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BINHLUAN bINHLUAN = db.BINHLUANs.Find(id);
            if (bINHLUAN == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaTinTuc = new SelectList(db.TINTUCs, "MaTinTuc", "TieuDe", bINHLUAN.MaTinTuc);
            return View(bINHLUAN);
        }

        // POST: BINHLUANs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaBinhLuan,NoiDung,HoTen,Email,MaTinTuc")] BINHLUAN bINHLUAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bINHLUAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaTinTuc = new SelectList(db.TINTUCs, "MaTinTuc", "TieuDe", bINHLUAN.MaTinTuc);
            return View(bINHLUAN);
        }

        // GET: BINHLUANs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BINHLUAN bINHLUAN = db.BINHLUANs.Find(id);
            if (bINHLUAN == null)
            {
                return HttpNotFound();
            }
            return View(bINHLUAN);
        }

        // POST: BINHLUANs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BINHLUAN bINHLUAN = db.BINHLUANs.Find(id);
            db.BINHLUANs.Remove(bINHLUAN);
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
