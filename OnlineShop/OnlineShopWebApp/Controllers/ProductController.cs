using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Models.Interfaces;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsRepository products;
        private readonly ICartsRepository cartsRepository;

        public ProductController(IProductsRepository products, ICartsRepository cartsRepository)
        {
            this.products = products;
            this.cartsRepository = cartsRepository;
        }

        // GET: ProductController
        public ActionResult Index(int id)
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
