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
                //TODO
                //extract the last id from TripTable
                //enter the user with current Username in the TripGroup Table
                //if carAvailable is checked then make TripAdmin field of TripGroup table true
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
            SqlDataReader i = null;
            if (ret)
            {
                i = DB.DataRetrieve("select * from Trips t INNER JOIN AspNetUsers u ON u.id=t.created_by where t.id=" + id);
            }
            var details = new TripModel();

            try
            {
                while (i.Read())
                {
                    details.source = i["source"].ToString().ToUpper();
                    details.destination = i["destination"].ToString().ToUpper();
                    details.id = Convert.ToInt32(i["id"]);
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
            return View("TripDetails", details);
        }

        [HttpGet]
        public string JoinTrip(string id)
        {
            //TODO
            //Check if user is logged in    
            //if not logged in return 1
            //else
            //find the username of current user from ASPusers Table
            //retrive all the usernames already present in the TripGroup Table
            //check if the current username exists in the above retrived data
            //if the user exists then return 2
            //else 
            //add the user to the TripGroup table with id = id and people = curretUser and tripAdmin = false
            //and return - 3
            //above entire stuff will be inside try catch
            //catch - return 4
            return id;
        }

        [HttpGet]
        public bool ShowJoinButton(string id) {

            //TODO
            //retrive created_by from Trips table using id
            //check if current logged in user and created by user is same
            //if same return false - do not show join button
            //else return true - show join button

            bool bReturn = false;
            bool ret = DB.Open();
            SqlDataReader i = null;
            if (ret)
            {
                i = DB.DataRetrieve("select created_by from Trips t INNER JOIN AspNetUsers u ON u.id=t.created_by where t.id=" + id);
            }
            var details = new TripModel();

            try
            {
                while (i.Read())
                {
                    //details.created_by = i["created_by"].ToString();
                }
                DB.Close();
            }
            catch (Exception) { }

            return bReturn;
        }
    }
}
