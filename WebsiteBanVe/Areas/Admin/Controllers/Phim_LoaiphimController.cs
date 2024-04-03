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
    public class Phim_LoaiphimController : Controller
    {
        private MovieModels db = new MovieModels();

        // GET: Admin/Phim_Loaiphim
        public ActionResult Index()
        {
            var phim_Loaiphim = db.Phim_Loaiphim.Include(p => p.Loai_phim).Include(p => p.Phim);
            return View(phim_Loaiphim.ToList());
        }

        // GET: Admin/Phim_Loaiphim/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phim_Loaiphim phim_Loaiphim = db.Phim_Loaiphim.Find(id);
            if (phim_Loaiphim == null)
            {
                return HttpNotFound();
            }
            return View(phim_Loaiphim);
        }

        // GET: Admin/Phim_Loaiphim/Create
        public ActionResult Create()
        {
            ViewBag.id_loai_phim = new SelectList(db.Loai_phim, "id_loai_phim", "ten_loai_phim");
            ViewBag.id_phim = new SelectList(db.Phims, "id_phim", "ten_phim");
            return View();
        }

        // POST: Admin/Phim_Loaiphim/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_phim,id_loai_phim,trangthai")] Phim_Loaiphim phim_Loaiphim)
        {
            if (ModelState.IsValid)
            {
                db.Phim_Loaiphim.Add(phim_Loaiphim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_loai_phim = new SelectList(db.Loai_phim, "id_loai_phim", "ten_loai_phim", phim_Loaiphim.id_loai_phim);
            ViewBag.id_phim = new SelectList(db.Phims, "id_phim", "ten_phim", phim_Loaiphim.id_phim);
            return View(phim_Loaiphim);
        }

        // GET: Admin/Phim_Loaiphim/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phim_Loaiphim phim_Loaiphim = db.Phim_Loaiphim.Find(id);
            if (phim_Loaiphim == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_loai_phim = new SelectList(db.Loai_phim, "id_loai_phim", "ten_loai_phim", phim_Loaiphim.id_loai_phim);
            ViewBag.id_phim = new SelectList(db.Phims, "id_phim", "ten_phim", phim_Loaiphim.id_phim);
            return View(phim_Loaiphim);
        }

        // POST: Admin/Phim_Loaiphim/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_phim,id_loai_phim,trangthai")] Phim_Loaiphim phim_Loaiphim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phim_Loaiphim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_loai_phim = new SelectList(db.Loai_phim, "id_loai_phim", "ten_loai_phim", phim_Loaiphim.id_loai_phim);
            ViewBag.id_phim = new SelectList(db.Phims, "id_phim", "ten_phim", phim_Loaiphim.id_phim);
            return View(phim_Loaiphim);
        }

        // GET: Admin/Phim_Loaiphim/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phim_Loaiphim phim_Loaiphim = db.Phim_Loaiphim.Find(id);
            if (phim_Loaiphim == null)
            {
                return HttpNotFound();
            }
            return View(phim_Loaiphim);
        }

        // POST: Admin/Phim_Loaiphim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Phim_Loaiphim phim_Loaiphim = db.Phim_Loaiphim.Find(id);
            db.Phim_Loaiphim.Remove(phim_Loaiphim);
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
