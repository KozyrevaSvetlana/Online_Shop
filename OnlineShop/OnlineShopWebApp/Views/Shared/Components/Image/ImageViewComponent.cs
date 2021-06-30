using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;

namespace OnlineShopWebApp.Views.Shared.ViewComponents.ImageViewComponent
{
    public class ImageViewComponent : ViewComponent
    {
        private readonly UserManager<User> userManager;

        public ImageViewComponent(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            if (user.Image == null || user.Image == "")
            {
                return View("Image", "/img/profile.webp");
            }
            return View("Image", user.Image);
        }
    }
}
