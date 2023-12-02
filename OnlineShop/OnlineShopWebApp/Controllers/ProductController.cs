using Microsoft.AspNetCore.Mvc;
using Nelibur.ObjectMapper;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Helpers;
using ModelsLibrary.ModelsVM;
using System;
using System.Threading.Tasks;
using System.Linq;

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
            var product = await products.GetByIdAsync(id);
            var productVM = TinyMapper.Map<ProductViewModel>(product);
            return View(productVM);
        }

        [HttpPost]
        public async Task<ActionResult> Find(string result)
        {
            if (result != null)
            {
                TempData["Result"] = result;
                var searchResult = await products.Search(result.Split());
                return View(searchResult.Select(TinyMapper.Map<ProductViewModel>).ToList());
            }
            return View();
        }

    }
}
