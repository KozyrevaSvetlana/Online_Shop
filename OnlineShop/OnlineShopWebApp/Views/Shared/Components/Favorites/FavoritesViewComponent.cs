using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Views.Shared.ViewComponents.FavoritesViewComponent
{
    public class FavoritesViewComponent : ViewComponent
    {
        private readonly IFavoritesRepository favoritesRepository;
        private readonly UserManager<User> userManager;

        public FavoritesViewComponent(IFavoritesRepository favoritesRepository, UserManager<User> userManager)
        {
            this.userManager = userManager;
            this.favoritesRepository = favoritesRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var favoritesItemsCount = 0;
            var user = await userManager.GetUserAsync(HttpContext.User);
            if (user != null)
            {
                var favorites = await favoritesRepository.GetByIdAsync(null, user.Id);
                favoritesItemsCount = favorites?.Items.Count ?? 0;
            }
            return View("Favorites", favoritesItemsCount);
        }
    }
}
