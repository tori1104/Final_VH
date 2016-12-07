using DWD278_FinalProject_VH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace DWD278_FinalProject_VH.Controllers
{
    public class HomeController : Controller
    {
        private ToWatchListContext db = new ToWatchListContext();
        public ActionResult Index()

        
        {
            var Movie = db.ToWatchList
                .Include(t => t.Genre)
                .Include(t => t.Rating)
                .Include(t => t.TypeStatus)
                .Where(x => x.TypeStatusID == 1)
                .ToList();

            var Show = db.ToWatchList
                .Include(t => t.Genre)
                .Include(t => t.Rating)
                .Include(t => t.TypeStatus)
                .Where(x => x.TypeStatusID == 2)
                .ToList();

            var viewModel = new ToWatchListViewModel
            {
                Movie = Movie,
                Show = Show
            };

            return View(viewModel);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "";

            return View();
        }

    }
}