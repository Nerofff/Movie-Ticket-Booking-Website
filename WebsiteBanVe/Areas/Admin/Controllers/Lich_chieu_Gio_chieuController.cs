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
    public class Lich_chieu_Gio_chieuController : Controller
    {
        private MovieModels db = new MovieModels();

        // GET: Admin/Lich_chieu_Gio_chieu
        public ActionResult Index()
        {
            var lich_chieu_Gio_chieu = db.Lich_chieu_Gio_chieu.Include(l => l.Gio_Chieu).Include(l => l.Lich_chieu);
            return View(lich_chieu_Gio_chieu.ToList());
        }

        // GET: Admin/Lich_chieu_Gio_chieu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lich_chieu_Gio_chieu lich_chieu_Gio_chieu = db.Lich_chieu_Gio_chieu.Find(id);
            if (lich_chieu_Gio_chieu == null)
            {
                return HttpNotFound();
            }
            return View(lich_chieu_Gio_chieu);
        }

        // GET: Admin/Lich_chieu_Gio_chieu/Create
        public ActionResult Create()
        {
            ViewBag.id_gio_chieu = new SelectList(db.Gio_Chieu, "id_gio_chieu", "id_gio_chieu");
            ViewBag.id_lich_chieu = new SelectList(db.Lich_chieu, "id_lich_chieu", "id_lich_chieu");
            return View();
        }

        // POST: Admin/Lich_chieu_Gio_chieu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_lich_chieu,id_gio_chieu,trangthai")] Lich_chieu_Gio_chieu lich_chieu_Gio_chieu)
        {
            if (ModelState.IsValid)
            {
                db.Lich_chieu_Gio_chieu.Add(lich_chieu_Gio_chieu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_gio_chieu = new SelectList(db.Gio_Chieu, "id_gio_chieu", "id_gio_chieu", lich_chieu_Gio_chieu.id_gio_chieu);
            ViewBag.id_lich_chieu = new SelectList(db.Lich_chieu, "id_lich_chieu", "id_lich_chieu", lich_chieu_Gio_chieu.id_lich_chieu);
            return View(lich_chieu_Gio_chieu);
        }

        // GET: Admin/Lich_chieu_Gio_chieu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lich_chieu_Gio_chieu lich_chieu_Gio_chieu = db.Lich_chieu_Gio_chieu.Find(id);
            if (lich_chieu_Gio_chieu == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_gio_chieu = new SelectList(db.Gio_Chieu, "id_gio_chieu", "id_gio_chieu", lich_chieu_Gio_chieu.id_gio_chieu);
            ViewBag.id_lich_chieu = new SelectList(db.Lich_chieu, "id_lich_chieu", "id_lich_chieu", lich_chieu_Gio_chieu.id_lich_chieu);
            return View(lich_chieu_Gio_chieu);
        }

        // POST: Admin/Lich_chieu_Gio_chieu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_lich_chieu,id_gio_chieu,trangthai")] Lich_chieu_Gio_chieu lich_chieu_Gio_chieu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lich_chieu_Gio_chieu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_gio_chieu = new SelectList(db.Gio_Chieu, "id_gio_chieu", "id_gio_chieu", lich_chieu_Gio_chieu.id_gio_chieu);
            ViewBag.id_lich_chieu = new SelectList(db.Lich_chieu, "id_lich_chieu", "id_lich_chieu", lich_chieu_Gio_chieu.id_lich_chieu);
            return View(lich_chieu_Gio_chieu);
        }

        // GET: Admin/Lich_chieu_Gio_chieu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lich_chieu_Gio_chieu lich_chieu_Gio_chieu = db.Lich_chieu_Gio_chieu.Find(id);
            if (lich_chieu_Gio_chieu == null)
            {
                return HttpNotFound();
            }
            return View(lich_chieu_Gio_chieu);
        }

        // POST: Admin/Lich_chieu_Gio_chieu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lich_chieu_Gio_chieu lich_chieu_Gio_chieu = db.Lich_chieu_Gio_chieu.Find(id);
            db.Lich_chieu_Gio_chieu.Remove(lich_chieu_Gio_chieu);
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
