using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Helpers;
using ModelsLibrary.ModelsVM;
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

        public async Task<IActionResult> Index(int? page = 1, int? count = 9)
        {
            var result = await products.Paginate(count ?? 9, page ?? 1);
            var index = new IndexViewModel()
            {
                Products = result.Item1.ToProductViewModels(),
                PageInfo = new PageInfo()
                {
                    PageNumber = page ?? 1,
                    PageSize = count ?? 9,
                    TotalItems = result.Item2
                }
            };
            return View(index);
        }
    }
}
