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
    public class Phim_DienVienController : Controller
    {
        private MovieModels db = new MovieModels();

        // GET: Admin/Phim_DienVien
        public ActionResult Index()
        {
            var phim_DienVien = db.Phim_DienVien.Include(p => p.Dien_Vien).Include(p => p.Phim);
            return View(phim_DienVien.ToList());
        }

        // GET: Admin/Phim_DienVien/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phim_DienVien phim_DienVien = db.Phim_DienVien.Find(id);
            if (phim_DienVien == null)
            {
                return HttpNotFound();
            }
            return View(phim_DienVien);
        }

        // GET: Admin/Phim_DienVien/Create
        public ActionResult Create()
        {
            ViewBag.id_dien_vien = new SelectList(db.Dien_Vien, "id_dien_vien", "ten_dien_vien");
            ViewBag.id_phim = new SelectList(db.Phims, "id_phim", "ten_phim");
            return View();
        }

        // POST: Admin/Phim_DienVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_phim,id_dien_vien,vaidien")] Phim_DienVien phim_DienVien)
        {
            if (ModelState.IsValid)
            {
                db.Phim_DienVien.Add(phim_DienVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_dien_vien = new SelectList(db.Dien_Vien, "id_dien_vien", "ten_dien_vien", phim_DienVien.id_dien_vien);
            ViewBag.id_phim = new SelectList(db.Phims, "id_phim", "ten_phim", phim_DienVien.id_phim);
            return View(phim_DienVien);
        }

        // GET: Admin/Phim_DienVien/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phim_DienVien phim_DienVien = db.Phim_DienVien.Find(id);
            if (phim_DienVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_dien_vien = new SelectList(db.Dien_Vien, "id_dien_vien", "ten_dien_vien", phim_DienVien.id_dien_vien);
            ViewBag.id_phim = new SelectList(db.Phims, "id_phim", "ten_phim", phim_DienVien.id_phim);
            return View(phim_DienVien);
        }

        // POST: Admin/Phim_DienVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_phim,id_dien_vien,vaidien")] Phim_DienVien phim_DienVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phim_DienVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_dien_vien = new SelectList(db.Dien_Vien, "id_dien_vien", "ten_dien_vien", phim_DienVien.id_dien_vien);
            ViewBag.id_phim = new SelectList(db.Phims, "id_phim", "ten_phim", phim_DienVien.id_phim);
            return View(phim_DienVien);
        }

        // GET: Admin/Phim_DienVien/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phim_DienVien phim_DienVien = db.Phim_DienVien.Find(id);
            if (phim_DienVien == null)
            {
                return HttpNotFound();
            }
            return View(phim_DienVien);
        }

        // POST: Admin/Phim_DienVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Phim_DienVien phim_DienVien = db.Phim_DienVien.Find(id);
            db.Phim_DienVien.Remove(phim_DienVien);
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
