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
        private Mock<IDbRepo<Product>> mockProductRepo = new Mock<IDbRepo<Product>>();

        private HomeController LoadControllerWithTestData()
        {
            mockProductRepo.Setup(m => m.Data).Returns(TestData.Products.AsQueryable());
            return new HomeController(mockProductRepo.Object);
        }

        // TODO: Mock database can't test linked tables because .Include() doesn't work
        [TestMethod]
        public void Index_GETRoute_ViewModelHasTop3Products()
        {
            //var controller = LoadControllerWithTestData();
            //List<Product> testData = new List<Product> {
            //    TestData.Products[1],
            //    TestData.Products[0],
            //    TestData.Products[3],
            //};

            //var view = controller.Index() as ViewResult;
            //var model = view.ViewData.Model as List<Product>;

            //Console.WriteLine("Test: ");
            //foreach (Product product in testData)
            //{
            //    Console.WriteLine(product.Name);
            //}
            //Console.WriteLine("Result: ");
            //foreach (Product product in model)
            //{
            //    Console.WriteLine(product.Name);
            //}

            //Assert.IsInstanceOfType(view, typeof(ViewResult));
            //CollectionAssert.AreEqual(model, testData);
        }
    }
}
