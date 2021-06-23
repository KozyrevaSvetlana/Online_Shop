using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Helpers;

namespace OnlineShopWebApp.Views.Shared.ViewComponents.CartCountViewComponents
{
    public class CartCountViewComponent : ViewComponent
    {
        private readonly ICartsRepository cartsRepository;
        private readonly UserManager<User> userManager;

        public CartCountViewComponent(ICartsRepository cartsRepository, UserManager<User> userManager)
        {
            this.userManager = userManager;
            this.cartsRepository = cartsRepository;
        }

        public IViewComponentResult Invoke()
        {
            var productCounts = 0;
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            var cart = new Cart();
            if (user != null)
            {
                cart = cartsRepository.TryGetByUserId(user.UserName);
            }
            else
            {
                var userName = Request.Cookies["id"];
                cart = cartsRepository.TryGetByUserId(userName);
            }
            var cartViewModel = cart.ToCartViewModel();
            productCounts = cartViewModel?.Amount ?? 0;
            return View("CartCount", productCounts);
        }
    }
}
