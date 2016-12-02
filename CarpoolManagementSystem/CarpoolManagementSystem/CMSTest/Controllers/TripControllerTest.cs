using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoginSignup.Controllers;
using LoginSignup.Models;
using System.Web.Mvc;

namespace CMSTest
{
    [TestClass]
    public class TripControllerTest
    {
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
