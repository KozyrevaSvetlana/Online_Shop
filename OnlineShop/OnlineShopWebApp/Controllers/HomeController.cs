using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsRepository products;
        private readonly IOrdersRepository ordersRepository;

        public HomeController(IProductsRepository products, IOrdersRepository ordersRepository)
        {
            this.products = products;
            this.ordersRepository = ordersRepository;
        }

        public IActionResult Index()
        {
            Constants.UserId = "UserId";
            return View(Mapping.ToProductViewModels(products.AllProducts));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Logout()
        {
            Constants.UserId = "UserId";
            return RedirectToAction("Index");
        }
        
    }
}
