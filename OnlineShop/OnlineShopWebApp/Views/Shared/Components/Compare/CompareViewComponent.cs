using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Helpers;

namespace OnlineShopWebApp.Views.Shared.ViewComponents.FavoritesViewComponent
{
    public class CompareViewComponent : ViewComponent
    {
        private readonly ICompareRepository compareRepository;
        private readonly UserManager<User> userManager;

        public CompareViewComponent(ICompareRepository compareRepository, UserManager<User> userManager)
        {
            this.userManager = userManager;
            this.compareRepository = compareRepository;
        }

        public IViewComponentResult Invoke()
        {
            var compareItemsCount = 0;
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            if (user != null)
            {
                var compare = compareRepository.TryGetByCompareId(user.UserName);
                var compareViewModel = Mapping.ToCompareViewModel(compare);
                compareItemsCount = compareViewModel?.Items.Count ?? 0;
            }
            return View("Compare", compareItemsCount);
        }
    }
}
