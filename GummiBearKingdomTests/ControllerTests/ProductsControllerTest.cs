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
    public class ProductsControllerTest
    {
        Mock<IDbRepo<Product>> mockProductRepo = new Mock<IDbRepo<Product>>();

        private void LoadTestData()
        {
            mockProductRepo.Setup(m => m.Data).Returns(TestData.Products.AsQueryable());
        }

        [TestMethod]
        public void Index_GETRoute_ViewModelIsProductList()
        {
            LoadTestData();
            Product[] testData = TestData.Products;
            var controller = new ProductsController(mockProductRepo.Object);

            var view = controller.Index() as ViewResult;
            var model = view.ViewData.Model as List<Product>;

            Assert.IsInstanceOfType(view, typeof(ViewResult));
            CollectionAssert.AreEqual(model, testData);
        }
    }
}
