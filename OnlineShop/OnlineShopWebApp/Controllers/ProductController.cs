using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Helpers;
using System;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsRepository products;

        public ProductController(IProductsRepository products)
        {
            this.products = products;
        }

        public async Task<ActionResult> Index(Guid id)
        {
            var result = await products.GetProductById(id);
            return View(result.ToProductViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Find(string result)
        {
            if (result != null)
            {
                TempData["Result"] = result;
                var searchResult = await products.SeachProduct(result.Split());
                return View(searchResult.ToProductViewModels());
            }
            return View();
        }

    }
}
