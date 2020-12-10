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
    class PodcastControllerTest
    {
        [TestMethod]
        public void All()
        {
            // Arrange
            PodcastController controller = new PodcastController();

            // Act
            ViewResult result = controller.All() as ViewResult;

            // Assert
            Assert.AreEqual("All", result.ViewName);
        }


    }
}
