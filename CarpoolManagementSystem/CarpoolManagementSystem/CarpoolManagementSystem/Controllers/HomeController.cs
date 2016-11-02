using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginSignup.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View("About");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View("Contact");
        }

        public ActionResult TripDetails()
        {
            return View("TripDetails");
        }

        public ActionResult AddTrip()
        {
            if(User.Identity.IsAuthenticated)
                return View();
            else
                return RedirectToAction("Login", "Account");
        }
    }
}