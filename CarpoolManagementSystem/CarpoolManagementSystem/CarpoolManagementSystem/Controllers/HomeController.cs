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
            if(User.Identity.IsAuthenticated)
                return View();
            else
                return RedirectToAction("Login", "Account");
        }
       [HttpPost]
        public ActionResult AddTrip(Trip t)
        {
            
                TripSam ts = new TripSam();
            //Trip td = new Trip();
            //td.source = "Boston";
            //td.destination = "New york";
            //td.date = Convert.ToDateTime("12/12/2016");
            //td.created_by = "23f74dc3-9a56-4507-a79b-27e05e6190ca";
            if(t.carAvailable==false)
            {
                t.vacant_seats = -1;
            }
            //if(t.carAvailable==true && t.vacant_seats==null)
            //{
            //    t.vacant_seats = 0;
            //}
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
            //return t_gc.x.Contains(tg);
            //td.carAvailable = false;
            //td.description = null;
            //td.vacant_seats = null;
            //try
            //{
            //    ts.SaveChanges();
            //}
            //catch (DbEntityValidationException ex)
            //{
            //    foreach (var entityValidationErrors in ex.EntityValidationErrors)
            //    {
            //        foreach (var validationError in entityValidationErrors.ValidationErrors)
            //        {
            //            Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
            //        }
            //    }
            //}
            //catch (DbUpdateException ex)
            //{


            //    Response.Write(ex.InnerException.Message);


            //}

            //catch(Exception ex)
            //{
            //    Response.Write(ex.Message);
            //}


            //return RedirectToAction("Index", "Home");
            return RedirectToAction("TripDetails/"+t.id, "Trip");


        }
    }
}