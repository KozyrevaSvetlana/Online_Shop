using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Views.Shared.ViewComponents.FilterViewComponent
{
    public class FilterViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View("Filter");
        }
    }
}
