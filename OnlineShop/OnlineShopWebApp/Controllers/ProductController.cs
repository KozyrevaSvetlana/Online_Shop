using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Models.Interfaces;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsRepository products;
        private readonly ICategoriesRepository categoriesRepository;

        public ProductController(IProductsRepository products, ICategoriesRepository categoriesRepository)
        {
            this.products = products;
            this.categoriesRepository = categoriesRepository;
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
        public ActionResult ShowCategory(int id)
        {
            return View(categoriesRepository.GetCategoryById(id));
        }

        public ActionResult ShowCategoryItem(string name)
        {
            TempData["Category"] = name;
            return View(products.SeachCategory(name));
        }
        
    }
}
