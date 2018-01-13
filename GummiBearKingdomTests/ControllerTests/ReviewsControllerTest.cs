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
using GummiBearKingdom.ViewModels;

namespace GummiBearKingdomTests.ControllerTests
{
    [TestClass]
    public class ReviewsControllerTest
    {
        private Mock<IDbRepo<Product>> mockProductRepo = new Mock<IDbRepo<Product>>();
        private Mock<IDbRepo<Review>> mockReviewRepo = new Mock<IDbRepo<Review>>();

        private ReviewsController LoadControllerWithTestData()
        {
            mockProductRepo.Setup(m => m.Data).Returns(TestData.Products.AsQueryable());
            mockReviewRepo.Setup(m => m.Data).Returns(TestData.Reviews.AsQueryable());
            return new ReviewsController(new ReviewsControllerSettings(mockProductRepo.Object, mockReviewRepo.Object));
        }

        [TestMethod]
        public void AddReviewToProduct_GETRouteWithIdParam_ViewModelWithProductData()
        {
            var controller = LoadControllerWithTestData();
            Product testProduct = TestData.Products[0];

            var view = controller.AddReviewToProduct(testProduct.Id) as ViewResult;
            var model = view.ViewData.Model as ModelForAddReviewToProduct;
            var resultProduct = model.CurrentProduct;

            Assert.IsInstanceOfType(view, typeof(ViewResult));
            Assert.AreEqual(testProduct, resultProduct);
        }
    }
}
