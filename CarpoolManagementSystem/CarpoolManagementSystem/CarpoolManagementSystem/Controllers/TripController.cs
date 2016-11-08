using LoginSignup.Models;
using System;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Collections.Generic;

namespace LoginSignup.Controllers
{
    public class TripController : Controller
    {
        public CodeDB DB = new CodeDB();
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveDataTrip(TripModel f)
        {
            bool bRet = DB.Open();

            if (bRet)
            {
                int i = DB.DataInsert("INSERT INTO Trips(source, destination, date, created_by, carAvailable, description, vacant_seats, estimated_cost) VALUES('" + f.source + "', '" + f.destination + "', '" + Convert.ToDateTime(f.date) + "', '" + f.created_by + "', '" + f.carAvailable + "', '" + f.description + "', '" + f.vacant_seats + "', '" + f.estimated_cost + "')");
                if (i > 0)
                {
                    ModelState.AddModelError("Success", "Save Success");
                }
                else
                {
                    ModelState.AddModelError("Error", "Save Error");
                }
            }

            DB.Close();

            return RedirectToAction("Index", "Home");
        }       

        public ActionResult ShowTripData(SearchBarModel f)
        {
            SqlDataReader i = null;
            bool bRet = DB.Open();

            if (bRet)
            {
                string query;
                if (f.source == null && f.destination == null && f.date == null)   //all fields null
                {
                    query = "select id,source, destination, date, carAvailable, description, vacant_seats, estimated_cost from Trips";
                }
                else if (f.source == null && f.destination == null)      //only date is provided
                {
                    query = "select id,source, destination, date, carAvailable, description, vacant_seats, estimated_cost from Trips where date='" + f.date + "'";
                }
                else if (f.source == null && f.date == null)    //only destination is provided
                {
                    query = "select id,source, destination, date, carAvailable, description, vacant_seats, estimated_cost from Trips where destination='" + f.destination + "'";
                }
                else if (f.destination == null && f.date == null)   //only source is provided
                {
                    query = "select id,source, destination, date, carAvailable, description, vacant_seats, estimated_cost from Trips where source='" + f.source + "'";
                }
                else if (f.date == null)         //Source and destination are provided
                {
                    query = "select id,source, destination, date, carAvailable, description, vacant_seats, estimated_cost from Trips where source='" + f.source + "' and destination='" + f.destination + "'";
                }
                else if (f.destination == null)      //Source and date are provided
                {
                    query = "select id,source, destination, date, carAvailable, description, vacant_seats, estimated_cost from Trips where source='" + f.source + "' and date='" + f.date + "'";
                }
                else if (f.source == null)           //Source and destination are provided
                {
                    query = "select id,source, destination, date, carAvailable, description, vacant_seats, estimated_cost from Trips where destination='" + f.destination + "' and date='" + f.date + "'";
                }
                else               //all fields are provided
                {
                    query = "select id,source, destination, date, carAvailable, description, vacant_seats, estimated_cost from Trips where source='" + f.source + "' and destination='" + f.destination + "' and date='" + f.date + "'";
                }
                i = DB.DataRetrieve(query);
                if (i != null)
                {
                    ModelState.AddModelError("Success", "Save Success");
                }
                else
                {
                    ModelState.AddModelError("Error", "Save Error");
                }
            }

            List<TripModel> Trips = new List<TripModel>();
            try
            {
                while (i.Read())
                {
                    var details = new TripModel();
                    details.source = i["source"].ToString().ToUpper();
                    details.destination = i["destination"].ToString().ToUpper();

                    char[] delim = { ' ' };
                    details.date = i["date"].ToString().Split(delim)[0];
                    details.carAvailable = Convert.ToBoolean(i["carAvailable"]);
                    details.description = i["description"].ToString().ToUpperInvariant();
                    details.vacant_seats = Convert.ToInt32(i["vacant_seats"]);
                    details.estimated_cost = Convert.ToInt32(i["estimated_cost"]);
                    details.id = Convert.ToInt32(i["id"]);

                    Trips.Add(details);
                }
                DB.Close();
            }
            catch (Exception) { }
            return View("ShowTripData", Trips);
        }
        
        public ActionResult TripDetails(int id)
        {
            bool ret = DB.Open();
            SqlDataReader i=null;
            if (ret)
            {
                i = DB.DataRetrieve("select t.source,t.destination,t.date,t.vacant_seats,t.estimated_cost from Trips t INNER JOIN AspNetUsers u ON u.id=t.created_by where t.id=" + id);
            }
            var details = new TripModel();

            try
            {
                while (i.Read())
                {
                    details.source = i["source"].ToString().ToUpper();
                    details.destination = i["destination"].ToString().ToUpper();

                    char[] delim = { ' ' };
                    details.date = i["date"].ToString().Split(delim)[0];
                    details.carAvailable = Convert.ToBoolean(i["carAvailable"]);
                    details.description = i["description"].ToString().ToUpper();
                    details.vacant_seats = Convert.ToInt32(i["vacant_seats"]);
                    details.estimated_cost = Convert.ToInt32(i["estimated_cost"]);
                }
                DB.Close();
            }
            catch (Exception) { }
            return View(details);
        } 
    }
}
