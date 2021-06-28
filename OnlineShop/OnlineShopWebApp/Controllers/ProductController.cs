using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Helpers;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsRepository products;

        public ProductController(IProductsRepository products)
        {
            this.products = products;
        }

        public ActionResult Index(Guid id)
        {
            var result = products.GetProductById(id);
            return View(result.ToProductViewModel());
        }

        [HttpPost]
        public IActionResult Find(string result)
        {
            if (result != null)
            {
                TempData["Result"] = result;
                var searchResult = products.SeachProduct(result.Split());
                return View(searchResult.ToProductViewModels());
            }
            return View();
        }
        
    }
}
