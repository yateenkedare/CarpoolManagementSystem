using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoginSignup.Controllers;
using LoginSignup.Models;
using System.Web.Mvc;
using CMSTest.TripClasses;

namespace CMSTest
{
    [TestClass]
    public class TripControllerTest
    {
        [TestMethod]
        public void TestTripController_TripDetails()
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
    
    //[TestMethod]
    //public void ShowTripReturnTest()
    //{
    //    var controller = new TripController();
    //    var db = new CodeDB();
    //    var searchbarmodel = new SearchBarModel(){
    //        source = "charlotte",
    //        destination = "new york",
    //        date = "01/01/2026" };
    //    var result = controller.ShowTripData(searchbarmodel) as ViewResult;
    //    Assert.AreEqual("ShowTripData", result.ViewName);
    //}

    //[TestMethod]
    //public void TripdetailsReturnTest()
    //{
    //    var controller = new TripController();
    //    var DB = new CodeDB();
    //    var result = controller.TripDetails(7) as ViewResult;
    //    Assert.AreEqual("TripDetails", result.ViewName);
    //}

    //[TestMethod]
    //public void ShowTripTest()
    //{
    //    var controller = new TripController();
    //    CodeDB DB = new CodeDB();
    //    var result = controller.ShowJoinButton("7");
    //    Assert.AreEqual(true, result);
    //}

    [TestMethod]
        public void ShowJoinButtonTest()
        {
            var controller = new TripController();
            var result =controller.ShowJoinButton("1");
            Assert.AreEqual(true, result);
        }
    }
}
