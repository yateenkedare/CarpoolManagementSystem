using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoginSignup.Controllers;
using LoginSignup.Models;
using System.Web.Mvc;

namespace LoginSignup.test
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void IndexReturnTest()
        {
            var controller = new HomeController();
            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }
        [TestMethod]
        public void AboutViewbagTest()
        {
            var controller = new HomeController();
            var result = controller.About() as ViewResult;
            Assert.AreEqual("Your application description page.", result.ViewData["Message"]);
        }
        [TestMethod]
        public void ContactViewbagTest()
        {
            var controller = new HomeController();
            var result = controller.Contact() as ViewResult;
            Assert.AreEqual("Your contact page.", result.ViewData["Message"]);
        }
        [TestMethod]
        public void TripDetailsReturnTest()
        {
            var controller = new HomeController();
            var result = controller.TripDetails() as ViewResult;
            Assert.AreEqual("TripDetails", result.ViewName);
        }
        [TestMethod]
        public void AboutReturnTest()
        {
            var controller = new HomeController();
            var result = controller.About() as ViewResult;
            Assert.AreEqual("About", result.ViewName);
        }
        [TestMethod]
        public void ContactReturnTest()
        {
            var controller = new HomeController();
            var result = controller.Contact() as ViewResult;
            Assert.AreEqual("Contact", result.ViewName);
        }
        
        [TestMethod]
        public void RegisterReturnTest()
        {
            var controller = new AccountController();
            var result = controller.Register() as ViewResult;
            Assert.AreEqual("Register", result.ViewName);
        }
    }
}

