using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Models.Interfaces;

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
