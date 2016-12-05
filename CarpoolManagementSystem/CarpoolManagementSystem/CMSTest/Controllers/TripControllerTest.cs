using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoginSignup.Controllers;
using LoginSignup.Models;
using System.Web.Mvc;
using CMSTest.TripClasses;
using System.Collections.Generic;

namespace CMSTest
{
    [TestClass]
    public class TripControllerTest
    {
        [TestMethod]
        public void TripDetailsTest()
        {
            TestTripDbset a = new TestTripDbset();
            Trip a1 = new Trip
            {
                id = 1,
                source = "durham",
                destination = "hyderabad",
                created_by = "bhanu",
                carAvailable = true,
                vacant_seats = 4,
                estimated_cost = 25,
                description = null
            };
            Trip a2 = new Trip
            {
                id = 2,
                source = "charlotte",
                destination = "chapel hill",
                created_by = "koushik",
                carAvailable = true,
                vacant_seats = 3,
                estimated_cost = 30,
                description = "xyz"
            };
            a.Add(a1);
            a.Add(a2);

            TestDbContextTrip t_c_t = new TestDbContextTrip(a);
            t_c_t.Trips.Add(a1);
            t_c_t.Trips.Add(a2);
            var controller = new TripController(t_c_t);
            var result = controller.TripDetails(1) as ViewResult;
            var model = controller.ViewData.Model;
            Assert.AreEqual(a1, model);
        }

        [TestMethod]
        public void ShowTripDataTest()
        {
            TestTripDbset trips = new TestTripDbset();
            Trip trip1 = new Trip
            {
                id = 1,
                source = "durham",
                destination = "hyderabad",
                created_by = "bhanu",
                carAvailable = true,
                vacant_seats = 4,
                estimated_cost = 25,
                description = null
            };
            Trip trip2 = new Trip
            {
                id = 2,
                source = "charlotte",
                destination = "chapel hill",
                created_by = "koushik",
                carAvailable = true,
                vacant_seats = 3,
                estimated_cost = 30,
                description = "xyz"
            };
            trips.Add(trip1);
            trips.Add(trip2);

            TestDbContextTrip t_c_t = new TestDbContextTrip(trips);
            t_c_t.Trips.Add(trip1);
            t_c_t.Trips.Add(trip2);

            SearchBarModel searchBarModel = new SearchBarModel
            {
                source = "charlotte",
            };

            var tripController = new TripController(t_c_t);
            var result = tripController.ShowTripData(searchBarModel) as ViewResult;
            List<Trip> model = (List < Trip >) tripController.ViewData.Model;
            Assert.AreEqual(trip2, model[0]);
        }

        [TestMethod]
        public void ShowTripReturnTest()
        {
            var controller = new TripController();
            var searchbarmodel = new SearchBarModel()
            {
                source = "charlotte",
                destination = "new york",
                date = "01/01/2026"
            };
            var result = controller.ShowTripData(searchbarmodel) as ViewResult;
            Assert.AreEqual("ShowTripData", result.ViewName);
        }

        [TestMethod]
        public void TripdetailsReturnTest()
        {
            TestTripDbset a = new TestTripDbset();
            Trip a1 = new Trip
            {
                id = 1,
                source = "durham",
                destination = "hyderabad",
                created_by = "bhanu",
                carAvailable = true,
                vacant_seats = 4,
                estimated_cost = 25,
                description = null
            };
            a.Add(a1);
            TestDbContextTrip t_c_t = new TestDbContextTrip(a);
            t_c_t.Trips.Add(a1);
            var controller = new TripController(t_c_t);
            var result = controller.TripDetails(1) as ViewResult;
            Assert.AreEqual("TripDetails", result.ViewName);
        }

        [TestMethod]
        public void ShowJoinButtonTest()
        {
            TestTripDbset a = new TestTripDbset();
            Trip a1 = new Trip
            {
                id = 1,
                source = "durham",
                destination = "hyderabad",
                created_by = "bhanu",
                carAvailable = true,
                vacant_seats = 4,
                estimated_cost = 25,
                description = null
            };
            a.Add(a1);
            TestDbContextTrip t_c_t = new TestDbContextTrip(a);
            t_c_t.Trips.Add(a1);
            var controller = new TripController(t_c_t);
            var result =controller.ShowJoinButton("1");
            Assert.AreEqual("3", result);
        }
    }
}
