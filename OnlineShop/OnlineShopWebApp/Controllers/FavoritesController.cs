using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Helpers;
using System;
using System.Threading.Tasks;

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
        public async Task<IActionResult> IndexAsync()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var cart = favoritesRepository.TryGetByUserId(user.UserName);
            return View(cart.ToFavoritesViewModel());
        }

        public async Task<IActionResult> AddAsync(Guid id)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var product = productsRepository.GetProductById(id);
            favoritesRepository.Add(product, user.UserName);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> ClearAsync()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            favoritesRepository.Clear(user.UserName);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            favoritesRepository.DeleteItem(id, user.UserName);
            return RedirectToAction("Index");
        }
    }
}
