using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedicMvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Home Page.";

            return View();
        }

        public ActionResult Communicate()
        {
            ViewBag.Message = "Communicate with Doctors and Nurses";

            return View();
        }

        public ActionResult Medicine()
        {
            ViewBag.Message = "Medicine info page.";

            return View();
        }

        public ActionResult Discharge()
        {
            ViewBag.Message = "Discharge informationn page.";

            return View();
        }

        public ActionResult Rating()
        {
            ViewBag.Message = "Hospital Rating page.";

            return View();
        }

        public ActionResult Pain()
        {
            ViewBag.Message = "Pain Management page.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
