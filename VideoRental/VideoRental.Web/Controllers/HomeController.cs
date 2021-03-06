﻿using System.Web.Mvc;
using VideoRental.Web.Resolver;

namespace VideoRental.Web.Controllers
{   
    [LoggedAs(Roles = "Admin, Staff, Guest")]
    public class HomeController : Controller
    {
        [LoggedAs(Roles = "Admin, Staff, Guest")]
        public ActionResult Index()
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
    }
}