using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Views.Shared.ViewComponents.ImageViewComponent
{
    public class ImageViewComponent : ViewComponent
    {
        private readonly UserManager<User> userManager;

        public ImageViewComponent(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            if (user.Image == null || user.Image == "")
            {
                return View("Image", "/img/profile.webp");
            }
            return View("Image", user.Image);
        }
    }
}
