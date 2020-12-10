using Microsoft.VisualStudio.TestTools.UnitTesting;
using podcast_web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace podcast_web.Test.Controllers
{
    [TestClass]
    class AuthorControllerTest
    {
        [TestMethod]
        public void IndexViewEqualIndexCshtml()
        {
            AuthorController controller = new AuthorController();

            ViewResult result = controller.Authors() as ViewResult;

            Assert.AreEqual("Authors", result.ViewName);
        }

        [TestMethod]
        public void IndexViewResultNotNull()
        {
            AuthorController controller = new AuthorController();

            ViewResult result = controller.Authors() as ViewResult;

            Assert.IsNotNull(result);
        }

    }
}
