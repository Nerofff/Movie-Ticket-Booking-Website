using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanVe.Models;

namespace WebsiteBanVe.Controllers
{
    public class HomeController : Controller
    {
        MovieModels contextMovie = new MovieModels();
        Ve veContext = new Ve();
        private static String ngay = DateTime.Now.ToString();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(int id_phim, string NgaySearch)
        {
            ngay = NgaySearch;
            var Detail = contextMovie.Phims.FirstOrDefault(p => p.id_phim == id_phim);
            if (Detail == null)
            {
                return HttpNotFound("Không tìm thấy phim");
            }
            return View("MoviePage", Detail);
        }

        public ActionResult NhapVe(int id_phim, string selectedSeats)
        {
            string NgayChieu = ngay;

            int id_lich_chieu = contextMovie.Lich_chieu.FirstOrDefault(p => p.id_phim == id_phim).id_lich_chieu;



            return View("MoviePage", id_phim);
        }

        public ActionResult Test()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

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
        public ActionResult RapPhim()
        {
            var listRap = contextMovie.Raps.ToList();
            return PartialView(listRap);
        }
        public ActionResult PhimPartial()
        {
            var listPhim = contextMovie.Phims.ToList();
            return PartialView(listPhim);
        }
        public ActionResult BookingPartial(int id_phim)
        {
            Lich_chieu lichchieu = contextMovie.Lich_chieu.FirstOrDefault(p => p.id_phim == id_phim && p.ngay_chieu.ToString() == ngay);            
            List<string> listghedadat = new List<string>();
            if (lichchieu != null)
            {

                listghedadat = contextMovie.Ves.Where(p => p.id_lich_chieu == lichchieu.id_lich_chieu)
                                      .Select(p => p.so_ghe_ngoi)
                                      .ToList();
            }
            else
            {
                listghedadat.Add("KhongCoLichChieu");
                
            }
            return PartialView(listghedadat);
        }

        public ActionResult Slider()
        {
            return PartialView();
        }

        public ActionResult NewMovie()
        {
            //var listPhim = contextMovie.Phims.Take(6).ToList();
            //Lấy ngược dưới lên
            var listPhim = contextMovie.Phims.OrderByDescending(p => p.id_phim).Take(6).ToList();
            return PartialView(listPhim);
        }

        public ActionResult MoviePage(int id)
        {
            var Detail = contextMovie.Phims.FirstOrDefault(p => p.id_phim == id);
            if (Detail == null)
            {
                return HttpNotFound("Không tìm thấy phim");
            }
            return View(Detail);
        }
        public ActionResult CinemaSearch(string keyword)
        {
            IEnumerable<Rap> model;

            if (!string.IsNullOrEmpty(keyword))
            {
                model = contextMovie.Raps.Where(r => r.ten_rap.Contains(keyword));
            }
            else
            {
                model = contextMovie.Raps;
            }

            ViewBag.SearchTerm = keyword;

            return View(model);
        }
        public ActionResult CategoryPartial()
        {
            var list = contextMovie.Phims.ToList();
            return PartialView(list);
        }
        public ActionResult SearchMovie(string searchString)
        {

            var results = (from m in contextMovie.Phims where m.ten_phim.Contains(searchString) select m);

            return View("SearchMovie", results.ToList());

        }
        public ActionResult GetTime(int id_phim)
        {
            Lich_chieu id_lichchieu = contextMovie.Lich_chieu.FirstOrDefault(p => p.id_phim == id_phim && p.ngay_chieu.ToString() == ngay);
            List<Lich_chieu_Gio_chieu> list = new List<Lich_chieu_Gio_chieu>();
            List<Gio_Chieu> listGioChieu = new List<Gio_Chieu>();
            if (id_lichchieu != null)
            {
                list = contextMovie.Lich_chieu_Gio_chieu.Where(p => p.id_lich_chieu == id_lichchieu.id_lich_chieu).ToList();
                
                foreach (Lich_chieu_Gio_chieu item in list)
                {
                    Gio_Chieu gio = contextMovie.Gio_Chieu.FirstOrDefault(p => p.id_gio_chieu == item.id_gio_chieu);
                    listGioChieu.Add(gio);
                }
            }
            return PartialView(listGioChieu);
        }
    }
}
