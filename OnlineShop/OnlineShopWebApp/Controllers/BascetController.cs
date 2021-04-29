using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static OnlineShopWebApp.Models.Basket;

namespace OnlineShopWebApp.Controllers
{
    public class BascetController : Controller
    {
        public IActionResult Index()
        {
            var result = Basket.GetBascet();
            return View(result);
        }
        public IActionResult AddNewProduct(int id)
        {
            BasketList basket = new BasketList(id);
            AddProduct(basket);
            var result = Basket.GetBascet();
            return View("Index", result);
        }
    }
}
