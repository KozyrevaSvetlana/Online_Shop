using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Helpers;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsRepository products;

        public HomeController(IProductsRepository products)
        {
            this.products = products;
        }

        public IActionResult Index()
        {
            return View(Mapping.ToProductViewModels(products.AllProducts));
        }
        public IActionResult Logout()
        {
            return RedirectToAction("Index");
        }
    }
}
