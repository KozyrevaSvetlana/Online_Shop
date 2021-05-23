using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models.Interfaces;

namespace OnlineShopWebApp.Views.Shared.ViewComponents.CartCountViewComponents
{
    public class CartCountViewComponent:ViewComponent
    {
        private readonly ICartsRepository cartsRepository;

        public CartCountViewComponent(ICartsRepository cartsRepository)
        {
            this.cartsRepository = cartsRepository;
        }

        public IViewComponentResult Invoke()
        {
            var cart = cartsRepository.TryGetByUserId(Constants.UserId);
            var cartItemsCount = cart?.Amount?? 0;
            return View("CartCount", cartItemsCount);
        }
    }
}
