using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoginSignup.Controllers;
using System.Web.Mvc;

namespace CMSTest
{
    [TestClass]
    public class AccountControllerTest
    {
        [TestMethod]
        public void LoginValidation()
        {
            AccountController ac = new AccountController();
            var result = ac.Register() as ViewResult;
            Assert.AreEqual("Register", result.ViewName);
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
