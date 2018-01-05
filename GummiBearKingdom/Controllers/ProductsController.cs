﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GummiBearKingdom.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GummiBearKingdom.Controllers
{
    public class ProductsController : Controller
    {
        private GummiBearKingdomContext db = new GummiBearKingdomContext();

        [HttpGet, Route("/products/")]
        public IActionResult Index()
        {
            var model = db.Products.ToList();
            return View(model);
        }

        [HttpGet, Route("/products/{id}")]
        public IActionResult Details(int id)
        {
            var model = db.Products.Find(id);
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
            db.Products.Add(newProduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet, Route("/products/{id}/delete")]
        public IActionResult RemoveProduct(int id)
        {
            var productToRemove = new Product { Id = id };
            db.Products.Remove(productToRemove);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
