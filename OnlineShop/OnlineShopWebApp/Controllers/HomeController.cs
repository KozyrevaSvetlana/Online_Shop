﻿using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var allProducts = ProductsRepository.GetAllProducts();
            return View(allProducts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
