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
        public void Index_ViewModelOfGETRoute_AllProducts()
        {
            LoadTestData();
            Product[] testData = TestData.Products;
            var controller = new ProductsController(mockProductRepo.Object);

            var view = controller.Index() as ViewResult;
            var model = view.ViewData.Model as List<Product>;

            Assert.IsInstanceOfType(view, typeof(ViewResult));
            CollectionAssert.AreEqual(model, testData);
        }

        [TestMethod]
        public void Details_ViewModelOfGETRouteWithIdParam_ProductWithThatId()
        {
            LoadTestData();
            Product testProduct = TestData.Products[0];
            var controller = new ProductsController(mockProductRepo.Object);

            var view = controller.Details(testProduct.Id) as ViewResult;
            var model = view.ViewData.Model as Product;

            Assert.AreEqual(testProduct, model);
        }
    }
}
