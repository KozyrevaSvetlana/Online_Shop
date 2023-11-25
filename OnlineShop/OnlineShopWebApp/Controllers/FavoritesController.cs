using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ModelsLibrary.ModelsDto;
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
            var cart = await favoritesRepository.GetByIdAsync(null, user.UserName);
            return View(cart.ToFavoritesViewModel());
        }

        public async Task<IActionResult> AddAsync(Guid id)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var product = await productsRepository.GetByIdAsync(id);
            await favoritesRepository.AddAsync(product.Id, user.UserName);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> ClearAsync()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            await favoritesRepository.ClearAsync(user.UserName);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            await favoritesRepository.DeleteAsync(id, user.UserName);
            return RedirectToAction("Index");
        }
    }
}
