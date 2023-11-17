using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        public async Task<IActionResult> Index(int page = 1, int count = 9)
        {
            var result = await products.Paginate(count, page);
            var index = new IndexViewModel()
            {
                Products = result.Item1.ToProductViewModels(),
                PageInfo = new PageInfo()
                {
                    PageNumber = page,
                    PageSize = count,
                    TotalItems = result.Item2
                }
            };
            return View(index);
        }
    }
}
