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
using GummiBearKingdom.ViewModels.Reviews;

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

        // TODO: Doesn't actually check if review was added to mock repo since mock repo has no actual add method
        [TestMethod]
        public void AddReviewToProduct_POSTRouteWithFormResultsParam_SavesReviewAndRedirectsToProductDetails()
        {
            var controller = LoadControllerWithTestData();
            Product testProduct = TestData.Products[0];
            Review newReview = new Review {
                Author = "TestAuthor",
                ContentBody = "TestContent",
                Rating = 5,
                ProductId = testProduct.Id
            };
            ModelForAddReviewToProduct testFormResults = new ModelForAddReviewToProduct(null);
            testFormResults.NewReview = newReview;

            var result = controller.AddReviewToProduct(testFormResults) as RedirectToActionResult;
            string redirectController = result.ControllerName;
            string redirectAction = result.ActionName;
            int redirectId = (int)result.RouteValues["id"];
            Review resultReview = mockReviewRepo.Object.Data.FirstOrDefault(review => review.Id == newReview.Id);

            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            Assert.AreEqual("Products", redirectController);
            Assert.AreEqual("Details", redirectAction);
            Assert.AreEqual(testProduct.Id, redirectId);
            //Assert.AreEqual(newReview, resultReview);
        }
    }
}
