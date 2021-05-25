using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Models.Interfaces;
using System.Diagnostics;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsRepository products;
        private readonly ICategoriesRepository categoriesRepository;
        private readonly IOrdersRepository ordersRepository;

        public HomeController(IProductsRepository products, ICartsRepository cartsRepository, ICategoriesRepository categoriesRepository, IOrdersRepository ordersRepository)
        {
            this.products = products;
            this.categoriesRepository = categoriesRepository;
            this.ordersRepository = ordersRepository;
        }

        public IActionResult Index()
        {
            var allProducts = products.AllProducts;
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
