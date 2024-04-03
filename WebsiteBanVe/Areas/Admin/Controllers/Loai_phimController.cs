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
    public class Loai_phimController : Controller
    {
        private MovieModels db = new MovieModels();

        // GET: Admin/Loai_phim
        public ActionResult Index()
        {
            return View(db.Loai_phim.ToList());
        }

        // GET: Admin/Loai_phim/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loai_phim loai_phim = db.Loai_phim.Find(id);
            if (loai_phim == null)
            {
                return HttpNotFound();
            }
            return View(loai_phim);
        }

        // GET: Admin/Loai_phim/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Loai_phim/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_loai_phim,ten_loai_phim")] Loai_phim loai_phim)
        {
            if (ModelState.IsValid)
            {
                db.Loai_phim.Add(loai_phim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loai_phim);
        }

        // GET: Admin/Loai_phim/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loai_phim loai_phim = db.Loai_phim.Find(id);
            if (loai_phim == null)
            {
                return HttpNotFound();
            }
            return View(loai_phim);
        }

        // POST: Admin/Loai_phim/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_loai_phim,ten_loai_phim")] Loai_phim loai_phim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loai_phim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loai_phim);
        }

        // GET: Admin/Loai_phim/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loai_phim loai_phim = db.Loai_phim.Find(id);
            if (loai_phim == null)
            {
                return HttpNotFound();
            }
            return View(loai_phim);
        }

        // POST: Admin/Loai_phim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Loai_phim loai_phim = db.Loai_phim.Find(id);
            db.Loai_phim.Remove(loai_phim);
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
