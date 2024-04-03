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
    public class VesController : Controller
    {
        private MovieModels db = new MovieModels();

        // GET: Admin/Ves
        public ActionResult Index()
        {
            var ves = db.Ves.Include(v => v.AspNetUser).Include(v => v.Lich_chieu);
            return View(ves.ToList());
        }

        // GET: Admin/Ves/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ve ve = db.Ves.Find(id);
            if (ve == null)
            {
                return HttpNotFound();
            }
            return View(ve);
        }

        // GET: Admin/Ves/Create
        public ActionResult Create()
        {
            ViewBag.id_user = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.id_lich_chieu = new SelectList(db.Lich_chieu, "id_lich_chieu", "id_lich_chieu");
            return View();
        }

        // POST: Admin/Ves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_ve,so_ghe_ngoi,ngay_mua_ve,id_user,id_lich_chieu,Gio_Chieu")] Ve ve)
        {
            if (ModelState.IsValid)
            {
                db.Ves.Add(ve);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_user = new SelectList(db.AspNetUsers, "Id", "Email", ve.id_user);
            ViewBag.id_lich_chieu = new SelectList(db.Lich_chieu, "id_lich_chieu", "id_lich_chieu", ve.id_lich_chieu);
            return View(ve);
        }

        // GET: Admin/Ves/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ve ve = db.Ves.Find(id);
            if (ve == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_user = new SelectList(db.AspNetUsers, "Id", "Email", ve.id_user);
            ViewBag.id_lich_chieu = new SelectList(db.Lich_chieu, "id_lich_chieu", "id_lich_chieu", ve.id_lich_chieu);
            return View(ve);
        }

        // POST: Admin/Ves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_ve,so_ghe_ngoi,ngay_mua_ve,id_user,id_lich_chieu,Gio_Chieu")] Ve ve)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ve).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_user = new SelectList(db.AspNetUsers, "Id", "Email", ve.id_user);
            ViewBag.id_lich_chieu = new SelectList(db.Lich_chieu, "id_lich_chieu", "id_lich_chieu", ve.id_lich_chieu);
            return View(ve);
        }

        // GET: Admin/Ves/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ve ve = db.Ves.Find(id);
            if (ve == null)
            {
                return HttpNotFound();
            }
            return View(ve);
        }

        // POST: Admin/Ves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ve ve = db.Ves.Find(id);
            db.Ves.Remove(ve);
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
