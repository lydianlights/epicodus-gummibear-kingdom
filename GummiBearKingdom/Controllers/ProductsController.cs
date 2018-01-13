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
    public class ProductsController : Controller
    {
        private IDbRepo<Product> productRepo;

        public ProductsController(IDbRepo<Product> productRepo = null)
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

        [HttpGet, Route("/products/")]
        public IActionResult Index()
        {
            List<Product> model = productRepo.Data.ToList();
            return View(model);
        }

        [HttpGet, Route("/products/{id}")]
        public IActionResult Details(int id)
        {
            Product model = productRepo.Data.Include(product => product.Reviews).FirstOrDefault(product => product.Id == id);
            return View(model);
        }

        [HttpGet, Route("/products/add")]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost, Route("/products/add")]
        public IActionResult AddProduct(Product newProduct)
        {
            productRepo.Save(newProduct);
            return RedirectToAction("Index");
        }

        [HttpGet, Route("/products/{id}/delete")]
        public IActionResult RemoveProduct(int id)
        {
            var productToRemove = new Product { Id = id };
            productRepo.Delete(productToRemove);
            return RedirectToAction("Index");
        }

        [HttpGet, Route("/products/delete-all")]
        public IActionResult RemoveAllProducts()
        {
            productRepo.DeleteAll();
            return RedirectToAction("Index");
        }
    }
}
