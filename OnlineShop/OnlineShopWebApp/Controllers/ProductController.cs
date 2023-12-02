using Microsoft.AspNetCore.Mvc;
using Nelibur.ObjectMapper;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Helpers;
using ModelsLibrary.ModelsVM;
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
            var result = await products.GetByIdAsync(id);
            var resultTest = TinyMapper.Map<ProductViewModel>(result);
            return View(result.ToProductViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Find(string result)
        {
            if (result != null)
            {
                TempData["Result"] = result;
                var searchResult = await products.Search(result.Split());
                return View(searchResult.ToProductViewModels());
            }
            return View();
        }

    }
}
