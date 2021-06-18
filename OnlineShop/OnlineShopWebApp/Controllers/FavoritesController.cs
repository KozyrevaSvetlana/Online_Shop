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
    public class FavoritesController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly IFavoritesRepository favoritesRepository;
        private readonly UserManager<User> userManager;

        public FavoritesController(IProductsRepository productsRepository, IFavoritesRepository favoritesRepository, UserManager<User> userManager)
        {
            this.productsRepository = productsRepository;
            this.favoritesRepository = favoritesRepository;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            var cart = favoritesRepository.TryGetByUserId(user.UserName);
            return View(cart.ToFavoritesViewModel());
        }

        public IActionResult Add(Guid id)
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            var product = productsRepository.GetProductById(id);
            favoritesRepository.Add(product, user.UserName);
            return RedirectToAction("Index");
        }
        public IActionResult Clear()
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            favoritesRepository.Clear(user.UserName);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(Guid id)
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            favoritesRepository.DeleteItem(id, user.UserName);
            return RedirectToAction("Index");
        }
    }
}
