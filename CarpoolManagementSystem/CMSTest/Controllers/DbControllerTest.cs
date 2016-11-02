using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoginSignup.Controllers;
using LoginSignup.Models;
using System.Web.Mvc;
namespace CMSTest
{
    /// <summary>
    /// Summary description for DbControllerTest
    /// </summary>
    [TestClass]
    public class DbControllerTest
    {
        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void CheckDbInsert()
        {
            var controller = new CodeDB();
            var result = controller.Open();
            Assert.AreNotEqual(result,true);

        }

        [TestMethod]
        public void CheckDbRetrive()
        {
            var controller = new CodeDB();
            var test = controller.Close();
            Assert.AreNotEqual(test, true);
        }
    }
}
