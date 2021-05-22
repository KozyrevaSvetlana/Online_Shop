using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Models.Interfaces;
using System.Diagnostics;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsRepository products;
        private readonly ICartsRepository cartsRepository;
        private readonly ICategoriesRepository categoriesRepository;

        public HomeController(IProductsRepository products, ICartsRepository cartsRepository, ICategoriesRepository categoriesRepository)
        {
            this.products = products;
            this.cartsRepository = cartsRepository;
            this.categoriesRepository = categoriesRepository;
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
