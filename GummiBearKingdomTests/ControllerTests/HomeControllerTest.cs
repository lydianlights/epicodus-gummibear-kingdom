using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GummiBearKingdom.Controllers;
using GummiBearKingdom.Data;
using GummiBearKingdom.Models;

namespace GummiBearKingdomTests.ControllerTests
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index_GETRoute_ViewResult()
        {
            var controller = new HomeController();

            var view = controller.Index() as ViewResult;

            Assert.IsInstanceOfType(view, typeof(ViewResult));
        }
    }
}
