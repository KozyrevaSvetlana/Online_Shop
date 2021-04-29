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
            List<BascetLine> result = GetBascet();
            return View(result);
        }
    }
}
