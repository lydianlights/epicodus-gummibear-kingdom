using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GummiBearKingdom.Data;
using GummiBearKingdom.Models;
using GummiBearKingdom.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GummiBearKingdom.Controllers
{
    public class ReviewsController : Controller
    {
        private IDbRepo<Product> productRepo;
        private IDbRepo<Review> reviewRepo;

        public ReviewsController(ReviewsControllerSettings settings = null)
        {
            if (settings == null)
            {
                settings = new ReviewsControllerSettings();
            }
            productRepo = settings.ProductRepo;
            reviewRepo = settings.ReviewRepo;
        }

        [HttpGet, Route("/products/{id}/reviews/add")]
        public IActionResult AddReviewToProduct(int productId)
        {
            Product currentProduct = productRepo.Data.FirstOrDefault(product => product.Id == productId);
            ModelForAddReviewToProduct model = new ModelForAddReviewToProduct(currentProduct);
            return View(model);
        }

        [HttpPost, Route("/products/{id}/reviews/add")]
        public IActionResult AddReviewToProduct(ModelForAddReviewToProduct formResults)
        {
            Review newReview = formResults.NewReview;
            reviewRepo.Save(newReview);
            return RedirectToAction("Details", "Products", new { id = newReview.ProductId });
        }
    }
}
