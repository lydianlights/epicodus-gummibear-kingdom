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
    }
}
