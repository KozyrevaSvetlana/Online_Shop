using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsRepository products;

        public ProductController(IProductsRepository products)
        {
            this.products = products;
        }

        public IActionResult Index(int id)
        {
            var result = products.GetProductById(id);
            //ViewBag.CartItemsCount = CartsRepository.GetAllAmounts(Constants.UserId);
            return View(result);
        }
    }
}
