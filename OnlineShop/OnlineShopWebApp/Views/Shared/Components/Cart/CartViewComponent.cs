using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Helpers;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Views.Shared.ViewComponents.FavoritesViewComponent
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartsRepository cartsRepository;
        private readonly UserManager<User> userManager;

        public CartViewComponent(ICartsRepository cartsRepository, UserManager<User> userManager)
        {
            this.cartsRepository = cartsRepository;
            this.userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var cart = cartsRepository.TryGetByUserId(user.UserName);
            if (cart==null)
            {
                var userName = Request.Cookies["id"];
                cart =cartsRepository.TryGetByUserId(userName);
            }
            return View("Cart", cart.ToCartViewModel());
        }
    }
}
