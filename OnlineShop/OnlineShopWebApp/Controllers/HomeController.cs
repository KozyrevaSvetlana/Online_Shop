using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsRepository products;
        private readonly IOrdersRepository ordersRepository;

        public HomeController(IProductsRepository products, IOrdersRepository ordersRepository)
        {
            this.products = products;
            this.ordersRepository = ordersRepository;
        }

        public IActionResult Index()
        {
            ordersRepository.CreateOrders();
            var allProducts = products.AllProducts;
            var productsViewModels = new List<ProductViewModel>();
            foreach (var product in allProducts)
            {
                var productViewModels = new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Cost = product.Cost,
                    Description = product.Description,
                    Image = product.Image
                };
                productsViewModels.Add(productViewModels);
            }
            return View(productsViewModels);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Logout()
        {
            Constants.UserId = "UserId";
            return RedirectToAction("Index");
        }
        
    }
}
