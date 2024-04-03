using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteBanVe.Models;

namespace WebsiteBanVe.Areas.Admin.Controllers
{
    public class Lich_chieuController : Controller
    {
        private MovieModels db = new MovieModels();

        // GET: Admin/Lich_chieu
        public ActionResult Index()
        {
            var lich_chieu = db.Lich_chieu.Include(l => l.Phim).Include(l => l.Phong);
            return View(lich_chieu.ToList());
        }

        // GET: Admin/Lich_chieu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lich_chieu lich_chieu = db.Lich_chieu.Find(id);
            if (lich_chieu == null)
            {
                return HttpNotFound();
            }
            return View(lich_chieu);
        }

        // GET: Admin/Lich_chieu/Create
        public ActionResult Create()
        {
            ViewBag.id_phim = new SelectList(db.Phims, "id_phim", "ten_phim");
            ViewBag.id_phong = new SelectList(db.Phongs, "id_phong", "ten_phong");
            return View();
        }

        // POST: Admin/Lich_chieu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_lich_chieu,ngay_chieu,gia_ve,id_phim,id_phong")] Lich_chieu lich_chieu)
        {
            if (ModelState.IsValid)
            {
                db.Lich_chieu.Add(lich_chieu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_phim = new SelectList(db.Phims, "id_phim", "ten_phim", lich_chieu.id_phim);
            ViewBag.id_phong = new SelectList(db.Phongs, "id_phong", "ten_phong", lich_chieu.id_phong);
            return View(lich_chieu);
        }

        // GET: Admin/Lich_chieu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lich_chieu lich_chieu = db.Lich_chieu.Find(id);
            if (lich_chieu == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_phim = new SelectList(db.Phims, "id_phim", "ten_phim", lich_chieu.id_phim);
            ViewBag.id_phong = new SelectList(db.Phongs, "id_phong", "ten_phong", lich_chieu.id_phong);
            return View(lich_chieu);
        }

        // POST: Admin/Lich_chieu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_lich_chieu,ngay_chieu,gia_ve,id_phim,id_phong")] Lich_chieu lich_chieu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lich_chieu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_phim = new SelectList(db.Phims, "id_phim", "ten_phim", lich_chieu.id_phim);
            ViewBag.id_phong = new SelectList(db.Phongs, "id_phong", "ten_phong", lich_chieu.id_phong);
            return View(lich_chieu);
        }

        // GET: Admin/Lich_chieu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lich_chieu lich_chieu = db.Lich_chieu.Find(id);
            if (lich_chieu == null)
            {
                return HttpNotFound();
            }
            return View(lich_chieu);
        }

        // POST: Admin/Lich_chieu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lich_chieu lich_chieu = db.Lich_chieu.Find(id);
            db.Lich_chieu.Remove(lich_chieu);
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
