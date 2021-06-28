using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Helpers;

namespace OnlineShopWebApp.Views.Shared.ViewComponents.AvatarViewComponent
{
    public class AvatarViewComponent : ViewComponent
    {
        private readonly UserManager<User> userManager;

        public AvatarViewComponent(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            if (user.Image == null || user.Image == "")
            {
                return View("Avatar", "/img/profile.webp");
            }
            return View("Avatar", user.Image);
        }
    }
}
