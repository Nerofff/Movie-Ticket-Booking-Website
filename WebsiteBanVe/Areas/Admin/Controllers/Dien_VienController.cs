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
    public class Dien_VienController : Controller
    {
        private MovieModels db = new MovieModels();

        // GET: Admin/Dien_Vien
        public ActionResult Index()
        {
            return View(db.Dien_Vien.ToList());
        }

        // GET: Admin/Dien_Vien/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dien_Vien dien_Vien = db.Dien_Vien.Find(id);
            if (dien_Vien == null)
            {
                return HttpNotFound();
            }
            return View(dien_Vien);
        }

        // GET: Admin/Dien_Vien/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Dien_Vien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_dien_vien,ten_dien_vien")] Dien_Vien dien_Vien)
        {
            if (ModelState.IsValid)
            {
                db.Dien_Vien.Add(dien_Vien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dien_Vien);
        }

        // GET: Admin/Dien_Vien/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dien_Vien dien_Vien = db.Dien_Vien.Find(id);
            if (dien_Vien == null)
            {
                return HttpNotFound();
            }
            return View(dien_Vien);
        }

        // POST: Admin/Dien_Vien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_dien_vien,ten_dien_vien")] Dien_Vien dien_Vien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dien_Vien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dien_Vien);
        }

        // GET: Admin/Dien_Vien/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dien_Vien dien_Vien = db.Dien_Vien.Find(id);
            if (dien_Vien == null)
            {
                return HttpNotFound();
            }
            return View(dien_Vien);
        }

        // POST: Admin/Dien_Vien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dien_Vien dien_Vien = db.Dien_Vien.Find(id);
            db.Dien_Vien.Remove(dien_Vien);
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
