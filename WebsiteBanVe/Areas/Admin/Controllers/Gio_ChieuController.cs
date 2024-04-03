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
    public class Gio_ChieuController : Controller
    {
        private MovieModels db = new MovieModels();

        // GET: Admin/Gio_Chieu
        public ActionResult Index()
        {
            return View(db.Gio_Chieu.ToList());
        }

        // GET: Admin/Gio_Chieu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gio_Chieu gio_Chieu = db.Gio_Chieu.Find(id);
            if (gio_Chieu == null)
            {
                return HttpNotFound();
            }
            return View(gio_Chieu);
        }

        // GET: Admin/Gio_Chieu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Gio_Chieu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_gio_chieu,gio_bat_dau")] Gio_Chieu gio_Chieu)
        {
            if (ModelState.IsValid)
            {
                db.Gio_Chieu.Add(gio_Chieu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gio_Chieu);
        }

        // GET: Admin/Gio_Chieu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gio_Chieu gio_Chieu = db.Gio_Chieu.Find(id);
            if (gio_Chieu == null)
            {
                return HttpNotFound();
            }
            return View(gio_Chieu);
        }

        // POST: Admin/Gio_Chieu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_gio_chieu,gio_bat_dau")] Gio_Chieu gio_Chieu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gio_Chieu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gio_Chieu);
        }

        // GET: Admin/Gio_Chieu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gio_Chieu gio_Chieu = db.Gio_Chieu.Find(id);
            if (gio_Chieu == null)
            {
                return HttpNotFound();
            }
            return View(gio_Chieu);
        }

        // POST: Admin/Gio_Chieu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gio_Chieu gio_Chieu = db.Gio_Chieu.Find(id);
            db.Gio_Chieu.Remove(gio_Chieu);
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
