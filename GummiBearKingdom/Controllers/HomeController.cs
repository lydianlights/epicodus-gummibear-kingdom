using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GummiBearKingdom.Data;
using GummiBearKingdom.Models;

namespace GummiBearKingdom.Controllers
{
    public class HomeController : Controller
    {
        private IDbRepo<Product> productRepo;

        public HomeController(IDbRepo<Product> productRepo = null)
        {
            if (productRepo == null)
            {
                this.productRepo = new EFProductRepo();
            }
            else
            {
                this.productRepo = productRepo;
            }
        }

        [HttpGet, Route("/")]
        public IActionResult Index()
        {
            List<Product> model = productRepo.Data
                .Include(product => product.Reviews)
                .OrderByDescending(product => product.Reviews.Count)
                .Take(3)
                .ToList();
            return View(model);
        }

        // HACK: Super lazy way of loading the test data into the actual db. REALLY BAD IDEA.
        // DON'T CALL THIS ROUTE IN TESTS
        [HttpGet, Route("/load-test-data")]
        public IActionResult LoadTestData()
        {
            EFProductRepo testProductRepo = new EFProductRepo();
            EFReviewRepo testReviewRepo = new EFReviewRepo();
            
            testProductRepo.DeleteAll();
            testReviewRepo.DeleteAll();

            foreach (Product product in TestData.Products.ToList())
            {
                testProductRepo.Save(product);
            }
            foreach (Review review in TestData.Reviews.ToList())
            {
                testReviewRepo.Save(review);
            }
            return RedirectToAction("Index");
        }
    }
}
