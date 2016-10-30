using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoginSignup.Controllers;
using System.Web.Mvc;

namespace CMSTest
{
    /// <summary>
    /// Summary description for AccountController
    /// </summary>
    [TestClass]
    public class AccountControllerTest
    {


        //public class ResolveAssemblyReference : TaskExtension
        //{

        //}

        [TestMethod]
        public void LoginValidation()
        {
            AccountController ac = new AccountController();
            var result = ac.Register() as ViewResult;
            Assert.AreEqual("Register", result.ViewName);
        }
    }
}
