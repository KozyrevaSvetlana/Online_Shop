﻿using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models.Interfaces;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsRepository products;

        public ProductController(IProductsRepository products)
        {
            this.products = products;
        }

        // GET: ProductController
        public ActionResult Index(Guid id)
        {
            var result = products.GetProductById(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Find(string result)
        {
            if (result != null)
            {
                TempData["Result"] = result;
                var searchResult = products.SeachProduct(result.Split());
                return View(searchResult);
            }
            return View();
        }
        
    }
}
