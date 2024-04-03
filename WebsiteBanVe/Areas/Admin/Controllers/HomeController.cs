using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanVe.Models;

namespace WebsiteBanVe.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        MovieModels contextMovie = new MovieModels();
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CinemaList()
        {
            return View("CinemaList");
        }
        public ActionResult MovieListFull()
        {
            return View("MovieListFull");
        }
        public ActionResult BookTicket()
        {
            return View("BookTicket");
        }
        public ActionResult AdminPage()
        {
            return View("AdminPage");
        }
    }
}