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
        [TestMethod]
        [ExpectedException(typeof(System.NullReferenceException))]
        public void ShowTripReturnTest()
        {
            var controller = new TripController();
            var db = new CodeDB();
            var searchbarmodel = new SearchBarModel(){
                source = "charlotte",
                destination = "new york",
                date = "01/01/2026" };
            var result = controller.ShowTripData(searchbarmodel) as ViewResult;
            Assert.AreEqual("ShowTripData", result.ViewName);
        }
    }
}
