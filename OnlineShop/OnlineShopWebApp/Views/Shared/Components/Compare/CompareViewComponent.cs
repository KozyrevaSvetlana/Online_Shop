using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ModelsLibrary.ModelsDto;
using ModelsLibrary.ModelsVM;
using Nelibur.ObjectMapper;
using OnlineShop.Db.Models.Interfaces;
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
                var compare = await compareRepository.GetByIdAsync(null, user.UserName);
                var compareViewModel = TinyMapper.Map<CompareViewModel>(compare);
                compareItemsCount = compareViewModel?.Items.Count ?? 0;
            }
            return View("Compare", compareItemsCount);
        }
    }
}
