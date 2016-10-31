using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoginSignup.Controllers;
using System.Web.Mvc;

namespace CMSTest
{
    [TestClass]
    public class AccountControllerTest
    {
        [TestMethod]
        public void RegisterReturnTest()
        {
            var controller = new AccountController();
            var result = controller.Register() as ViewResult;
            Assert.AreEqual("Register", result.ViewName);
        }
    }   
}
