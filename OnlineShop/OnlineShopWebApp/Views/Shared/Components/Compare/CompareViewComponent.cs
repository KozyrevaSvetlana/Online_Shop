using Microsoft.AspNetCore.Mvc;

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
            var compare = compareRepository.TryGetByUserId(Constants.UserId);
            var compareItemsCount = compare?.Items.Count??0;
            return View("Compare", compareItemsCount);
        }
    }
}
