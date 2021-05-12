using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Views.Shared.ViewComponents.FavoritesViewComponent
{
    public class FavoritesViewComponent : ViewComponent
    {
        private readonly IFavoritesRepository favoritesRepository;

        public FavoritesViewComponent(IFavoritesRepository favoritesRepository)
        {
            this.favoritesRepository = favoritesRepository;
        }

        public IViewComponentResult Invoke()
        {
            var favorites = favoritesRepository.TryGetByUserId(Constants.UserId);
            var favoritesItemsCount = favorites?.Items.Count??0;
            return View("Favorites", favoritesItemsCount);
        }
    }
}
