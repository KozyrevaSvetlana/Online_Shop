using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Helpers;

namespace OnlineShopWebApp.Views.Shared.ViewComponents.FavoritesViewComponent
{
    public class CompareViewComponent: ViewComponent
    {
        private readonly ICompareRepository compareRepository;

        public CompareViewComponent(ICompareRepository compareRepository)
        {
            this.compareRepository = compareRepository;
        }

        public IViewComponentResult Invoke()
        {
            var compare = compareRepository.TryGetByCompareId(Constants.UserId);
            var compareViewModel = Mapping.ToCompareViewModel(compare);
            var compareItemsCount = compareViewModel?.Items.Count ?? 0;
            return View("Compare", compareItemsCount);
        }
    }
}
