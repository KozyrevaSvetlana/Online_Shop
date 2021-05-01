using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static OnlineShopWebApp.Models.Cart;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ProductsRepository productRepository;
        public CartController()
        {
            productRepository = new ProductsRepository();
        }
        public IActionResult Index()
        {
            var cart = CartRepository.TryGetByUserId(Constants.UserId);
            return View(cart);
        }

        public IActionResult AddToBascet(int id)
        {
            var product = productRepository.TryGetById(id);
            CartRepository.Add(product, Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
