using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MessagingTest.Controllers
{
    public class MessagingController : Controller
    {

        // GET: Messaging
        [Authorize]
        
        public ActionResult Join()
        {
            ViewBag.MessagingActive = "active";
            return View();
        }
    }
}