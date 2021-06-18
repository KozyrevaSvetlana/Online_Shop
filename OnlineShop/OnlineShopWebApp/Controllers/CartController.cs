using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Helpers;
using System;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly ICartsRepository cartsRepository;
        private readonly UserManager<User> userManager;

        public CartController(IProductsRepository productsRepository, ICartsRepository cartsRepository, UserManager<User> userManager)
        {
            this.productsRepository = productsRepository;
            this.cartsRepository = cartsRepository;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            var cart = cartsRepository.TryGetByUserId(user.UserName);
            return View(cart.ToCartViewModel());
        }

        public IActionResult Add(Guid id)
        {
            var product = productsRepository.GetProductById(id);
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            cartsRepository.Add(product, user.UserName);
            return RedirectToAction("Index");
        }
        public IActionResult ChangeAmount(Guid id, int sign)
        {
            var product = productsRepository.GetProductById(id);
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            cartsRepository.ChangeAmount(product, sign, user.UserName);
            return RedirectToAction("Index");
        }
        public IActionResult Clear()
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            cartsRepository.ClearCart(user.UserName);
            return RedirectToAction("Index");
        }
    }
}
