using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using podcast_web.Controllers;

namespace podcast_web.Test.Controllers
{
    [TestClass]
    public class AuthControllerTest
    {
        [TestMethod]
        public void Login()
        {
            AuthController controller = new AuthController();
            // Act
            ViewResult result = controller.Login() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Register()
        {
            AuthController controller = new AuthController();
            // Act
            ViewResult result = controller.Register() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
