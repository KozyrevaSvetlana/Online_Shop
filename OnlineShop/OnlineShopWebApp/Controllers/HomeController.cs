using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
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
            ordersRepository.CreateOrders();
            var allProducts = products.AllProducts;
            return View(allProducts);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
