using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsRepository products;

        public HomeController(IProductsRepository products)
        {
            this.products = products;
        }

        public async Task<IActionResult> Index(int page, int count)
        {
            var allProducts = await products.GetAllAsync();
            var index = new IndexViewModel()
            {
                Products = allProducts.ToProductViewModels(),
                PageInfo = new PageInfo()
                {
                    PageNumber = 1,
                    PageSize = (int)Math.Ceiling((decimal)allProducts.Count() / 20)
                }
            };
            return base.View(index);
        }
    }
}
