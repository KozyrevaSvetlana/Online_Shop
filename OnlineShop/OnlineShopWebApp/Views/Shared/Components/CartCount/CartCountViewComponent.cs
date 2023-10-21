using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Helpers;
using System.Threading.Tasks;

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

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var productCounts = 0;
            var user = await userManager.GetUserAsync(HttpContext.User);
            var cart = new Cart();
            if (user != null)
            {
                cart = await cartsRepository.GetByIdAsync(null, user.Id);
            }
            else
            {
                var userId = Request.Cookies["id"];
                cart = await cartsRepository.GetByIdAsync(null, userId);
            }
            var cartViewModel = cart.ToCartViewModel();
            productCounts = cartViewModel?.Amount ?? 0;
            return View("CartCount", productCounts);
        }
    }
}
