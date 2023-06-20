using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Helpers;
using System.Threading.Tasks;

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

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var compareItemsCount = 0;
            var user = await userManager.GetUserAsync(HttpContext.User);
            if (user != null)
            {
                var compare = await compareRepository.TryGetByCompareId(user.UserName);
                var compareViewModel = compare.ToCompareViewModel();
                compareItemsCount = compareViewModel?.Items.Count ?? 0;
            }
            return View("Compare", compareItemsCount);
        }
    }
}
