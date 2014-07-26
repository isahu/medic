using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MessagingTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.HomeActive = "active";
            return View();
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";
            ViewBag.AboutActive = "active";
            return View();
        }

        public ActionResult Contact()
        {
            //ViewBag.Message = "Your contact page.";
            ViewBag.ContactActive = "active";
            return View();
        }
    }
}