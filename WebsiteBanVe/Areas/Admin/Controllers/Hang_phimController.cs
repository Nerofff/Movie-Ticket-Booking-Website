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
    public class Hang_phimController : Controller
    {
        private MovieModels db = new MovieModels();

        // GET: Admin/Hang_phim
        public ActionResult Index()
        {
            return View(db.Hang_phim.ToList());
        }

        // GET: Admin/Hang_phim/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hang_phim hang_phim = db.Hang_phim.Find(id);
            if (hang_phim == null)
            {
                return HttpNotFound();
            }
            return View(hang_phim);
        }

        // GET: Admin/Hang_phim/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Hang_phim/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_hang_phim,ten_hang_phim")] Hang_phim hang_phim)
        {
            if (ModelState.IsValid)
            {
                db.Hang_phim.Add(hang_phim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hang_phim);
        }

        // GET: Admin/Hang_phim/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hang_phim hang_phim = db.Hang_phim.Find(id);
            if (hang_phim == null)
            {
                return HttpNotFound();
            }
            return View(hang_phim);
        }

        // POST: Admin/Hang_phim/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_hang_phim,ten_hang_phim")] Hang_phim hang_phim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hang_phim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hang_phim);
        }

        // GET: Admin/Hang_phim/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hang_phim hang_phim = db.Hang_phim.Find(id);
            if (hang_phim == null)
            {
                return HttpNotFound();
            }
            return View(hang_phim);
        }

        // POST: Admin/Hang_phim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hang_phim hang_phim = db.Hang_phim.Find(id);
            db.Hang_phim.Remove(hang_phim);
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
