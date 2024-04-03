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
    public class RapsController : Controller
    {
        private MovieModels db = new MovieModels();

        // GET: Admin/Raps
        public ActionResult Index()
        {
            return View(db.Raps.ToList());
        }

        // GET: Admin/Raps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rap rap = db.Raps.Find(id);
            if (rap == null)
            {
                return HttpNotFound();
            }
            return View(rap);
        }

        // GET: Admin/Raps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Raps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_rap,ten_rap,dia_chi,tai_khoan")] Rap rap)
        {
            if (ModelState.IsValid)
            {
                db.Raps.Add(rap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rap);
        }

        // GET: Admin/Raps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rap rap = db.Raps.Find(id);
            if (rap == null)
            {
                return HttpNotFound();
            }
            return View(rap);
        }

        // POST: Admin/Raps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_rap,ten_rap,dia_chi,tai_khoan")] Rap rap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rap);
        }

        // GET: Admin/Raps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rap rap = db.Raps.Find(id);
            if (rap == null)
            {
                return HttpNotFound();
            }
            return View(rap);
        }

        // POST: Admin/Raps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rap rap = db.Raps.Find(id);
            db.Raps.Remove(rap);
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
