using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginSignup.Models;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;

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
            if (User.Identity.IsAuthenticated)
                return View();
            else
                return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public ActionResult AddTrip(Trip t)
        {

            TripSam ts = new TripSam();
            if (t.carAvailable == false)
            {
                t.vacant_seats = -1;
            }
            users us = new users();
            AspNetUser asp = us.AspNetUsers.Single(a => a.UserName == User.Identity.Name);
            t.created_by = asp.Id;
            ts.Trips.Add(t);
            ts.SaveChanges();
            TripGContext t_gc = new TripGContext();
            TripGroup tg = new TripGroup();
            tg.Id = t.id;
            tg.People = User.Identity.Name;
            tg.TripAdmin = t.carAvailable;
            t_gc.x.Add(tg);
            t_gc.SaveChanges();

            //if similar trip exists send mail to those people
            List<Trip> similarTrips = new List<Trip>();
            similarTrips = ts.Trips.Where(s => s.source == t.source && s.destination == t.destination).ToList();
            foreach (var s in similarTrips)
            {
                AspNetUser aspnetusers = us.AspNetUsers.Single(u => u.Id == s.created_by);
                if (aspnetusers.Email != User.Identity.Name)
                {
                    TripController tp = new TripController();
                    tp.SMTPSendEmail(aspnetusers.Email,
                    aspnetusers.Email + " has created a new trip similar to yours",
                    "A trip similar to yours has been created on CarpoolManagementSystem");
                }
            }

            return RedirectToAction("TripDetails/" + t.id, "Trip");


        }
    }
}