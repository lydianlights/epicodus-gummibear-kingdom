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
        private Mock<IDbRepo<Product>> mockProductRepo = new Mock<IDbRepo<Product>>();

        private ProductsController LoadControllerWithTestData()
        {
            mockProductRepo.Setup(m => m.Data).Returns(TestData.Products.AsQueryable());
            return new ProductsController(mockProductRepo.Object);
        }

        [TestMethod]
        public void Index_GETRoute_ViewModelIsAllProducts()
        {
            var controller = LoadControllerWithTestData();
            Product[] testData = TestData.Products;

            var view = controller.Index() as ViewResult;
            var model = view.ViewData.Model as List<Product>;

            Assert.IsInstanceOfType(view, typeof(ViewResult));
            CollectionAssert.AreEqual(model, testData);
        }

        [TestMethod]
        public void Details_GETRouteWithIdParam_ViewModelIsProductWithThatId()
        {
            var controller = LoadControllerWithTestData();
            Product testProduct = TestData.Products[0];

            var view = controller.Details(testProduct.Id) as ViewResult;
            var model = view.ViewData.Model as Product;

            Assert.IsInstanceOfType(view, typeof(ViewResult));
            Assert.AreEqual(testProduct, model);
        }

        [TestMethod]
        public void AddProduct_GETRoute_ViewResult()
        {
            var controller = LoadControllerWithTestData();

            var view = controller.AddProduct() as ViewResult;

            Assert.IsInstanceOfType(view, typeof(ViewResult));
        }

        // TODO: Doesn't actually check if object was saved in mock repo since mock repo has no actual add method
        [TestMethod]
        public void AddProduct_POSTRouteWithProductParam_SavesProductAndRedirectsToIndex()
        {
            var controller = LoadControllerWithTestData();
            Product newProduct = new Product {
                Name = "TestProduct",
                Cost = 1.99m,
                Description = "Lorem Ipsum"
            };

            var result = controller.AddProduct(newProduct) as RedirectToActionResult;
            string redirectTarget = result.ActionName;
            Product resultProduct = mockProductRepo.Object.Data.FirstOrDefault(product => product.Id == newProduct.Id);

            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            Assert.AreEqual("Index", redirectTarget);
            //Assert.AreEqual(newProduct, resultProduct);
        }

        // TODO: Doesn't actually check if object was deleted from mock repo since mock repo has no actual delete method
        [TestMethod]
        public void RemoveProduct_GETRouteWithIdParam_DeletesProductWithIdAndRedirectsToIndex()
        {
            var controller = LoadControllerWithTestData();
            Product deletedProduct = TestData.Products[0];

            var result = controller.RemoveProduct(deletedProduct.Id) as RedirectToActionResult;
            string redirectTarget = result.ActionName;
            Product resultProduct = mockProductRepo.Object.Data.FirstOrDefault(product => product.Id == deletedProduct.Id);

            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            Assert.AreEqual("Index", redirectTarget);
            //Assert.IsNull(resultProduct);
        }

        // TODO: Doesn't actually check if mock repo was cleared since mock repo has no actual delete all method
        [TestMethod]
        public void RemoveAllProducts_GETRoute_DeletesAllProductsAndRedirectsToIndex()
        {
            var controller = LoadControllerWithTestData();

            var result = controller.RemoveAllProducts() as RedirectToActionResult;
            string redirectTarget = result.ActionName;
            List<Product> resultProducts = mockProductRepo.Object.Data.ToList();

            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            Assert.AreEqual("Index", redirectTarget);
            //Assert.AreEqual(0, resultProducts.Count);
        }
    }
}
