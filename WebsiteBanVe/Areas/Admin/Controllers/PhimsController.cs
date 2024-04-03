using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteBanVe.Models;

namespace WebsiteBanVe.Areas.Admin.Controllers
{
    public class PhimsController : Controller
    {
        private MovieModels db = new MovieModels();

        // GET: Admin/Phims
        public ActionResult Index()
        {
            var phims = db.Phims.Include(p => p.Hang_phim);
            return View(phims.ToList());
        }

        // GET: Admin/Phims/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phim phim = db.Phims.Find(id);
            if (phim == null)
            {
                return HttpNotFound();
            }
            return View(phim);
        }

        // GET: Admin/Phims/Create
        public ActionResult Create()
        {
            ViewBag.id_hang_phim = new SelectList(db.Hang_phim, "id_hang_phim", "ten_hang_phim");
            return View();
        }

        // POST: Admin/Phims/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "id_phim,ten_phim,tacgia,hinhanh,mo_ta,trailer,thoi_luong,id_hang_phim,Do_Tuoi,trang_Thai")] Phim phim)
        //{
        //    if (phim.ImageFile != null && phim.ImageFile.ContentLength > 0)
        //    {
        //        var fileName = Path.GetFileName(phim.ImageFile.FileName);
        //        var filePath = Path.Combine(Server.MapPath("~/Content/images/Movie"), fileName);
        //        phim.ImageFile.SaveAs(filePath);
        //        phim.hinhanh = "/Content/images/Movie/" + fileName;
        //    }
        //    return RedirectToAction("Index");
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_phim,ten_phim,tacgia,hinhanh,mo_ta,trailer,thoi_luong,id_hang_phim,Do_Tuoi,trang_Thai")] Phim phim)
        {
            // Kiểm tra xem đã có tệp tin được gửi đi không
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0]; // Lấy tệp tin đầu tiên từ danh sách các tệp tin gửi đi

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(Server.MapPath("~/Content/images/Movie"), fileName);
                    file.SaveAs(filePath);
                    phim.hinhanh = "/Content/images/Movie/" + fileName;
                }
            }
            if (ModelState.IsValid)
            {
                db.Phims.Add(phim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_hang_phim = new SelectList(db.Hang_phim, "id_hang_phim", "ten_hang_phim", phim.id_hang_phim);
            return View(phim);
        }


        // GET: Admin/Phims/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phim phim = db.Phims.Find(id);
            if (phim == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_hang_phim = new SelectList(db.Hang_phim, "id_hang_phim", "ten_hang_phim", phim.id_hang_phim);
            return View(phim);
        }

        // POST: Admin/Phims/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_phim,ten_phim,tacgia,hinhanh,mo_ta,trailer,thoi_luong,id_hang_phim,Do_Tuoi,trang_Thai")] Phim phim)
        {
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0]; // Lấy tệp tin đầu tiên từ danh sách các tệp tin gửi đi

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(Server.MapPath("~/Content/images/Movie"), fileName);
                    file.SaveAs(filePath);
                    phim.hinhanh = "/Content/images/Movie/" + fileName;
                }
            }
            if (ModelState.IsValid)
            {
                db.Entry(phim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_hang_phim = new SelectList(db.Hang_phim, "id_hang_phim", "ten_hang_phim", phim.id_hang_phim);
            return View(phim);
        }

        // GET: Admin/Phims/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phim phim = db.Phims.Find(id);
            if (phim == null)
            {
                return HttpNotFound();
            }
            return View(phim);
        }

        // POST: Admin/Phims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Phim phim = db.Phims.Find(id);
            db.Phims.Remove(phim);
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
