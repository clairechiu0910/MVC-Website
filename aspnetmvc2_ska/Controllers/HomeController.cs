using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using aspnetmvc2_ska.Models;
using aspnetmvc2_ska.Repositories;


namespace aspnetmvc2_ska.Controllers
{
    public class HomeController : Controller
    {
        private readonly NorthwindRepo _northwindRepo = new NorthwindRepo();

        public ActionResult Index()
        {
            List<Product> productsList = _northwindRepo.GetProductsList();
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
    }
}