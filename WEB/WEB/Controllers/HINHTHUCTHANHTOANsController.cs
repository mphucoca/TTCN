﻿using System;
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
    public class HINHTHUCTHANHTOANsController : Controller
    {
        private Model1 db = new Model1();

        // GET: HINHTHUCTHANHTOANs
        public ActionResult Index()
        {
            return View(db.HINHTHUCTHANHTOANs.ToList());
        }

        // GET: HINHTHUCTHANHTOANs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HINHTHUCTHANHTOAN hINHTHUCTHANHTOAN = db.HINHTHUCTHANHTOANs.Find(id);
            if (hINHTHUCTHANHTOAN == null)
            {
                return HttpNotFound();
            }
            return View(hINHTHUCTHANHTOAN);
        }

        // GET: HINHTHUCTHANHTOANs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HINHTHUCTHANHTOANs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHinhThucThanhToan,TenHinhThucThanhToan,MoTa")] HINHTHUCTHANHTOAN hINHTHUCTHANHTOAN)
        {
            if (ModelState.IsValid)
            {
                db.HINHTHUCTHANHTOANs.Add(hINHTHUCTHANHTOAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hINHTHUCTHANHTOAN);
        }

        // GET: HINHTHUCTHANHTOANs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HINHTHUCTHANHTOAN hINHTHUCTHANHTOAN = db.HINHTHUCTHANHTOANs.Find(id);
            if (hINHTHUCTHANHTOAN == null)
            {
                return HttpNotFound();
            }
            return View(hINHTHUCTHANHTOAN);
        }

        // POST: HINHTHUCTHANHTOANs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHinhThucThanhToan,TenHinhThucThanhToan,MoTa")] HINHTHUCTHANHTOAN hINHTHUCTHANHTOAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hINHTHUCTHANHTOAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hINHTHUCTHANHTOAN);
        }

        // GET: HINHTHUCTHANHTOANs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HINHTHUCTHANHTOAN hINHTHUCTHANHTOAN = db.HINHTHUCTHANHTOANs.Find(id);
            if (hINHTHUCTHANHTOAN == null)
            {
                return HttpNotFound();
            }
            return View(hINHTHUCTHANHTOAN);
        }

        // POST: HINHTHUCTHANHTOANs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HINHTHUCTHANHTOAN hINHTHUCTHANHTOAN = db.HINHTHUCTHANHTOANs.Find(id);
            db.HINHTHUCTHANHTOANs.Remove(hINHTHUCTHANHTOAN);
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
