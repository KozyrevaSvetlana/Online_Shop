using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Views.Shared.ViewComponents.CartCountViewComponents
{
    public class CartCountViewComponent : ViewComponent
    {
        private readonly ICartsRepository cartsRepository;

        public CartCountViewComponent(ICartsRepository cartsRepository)
        {
            this.cartsRepository = cartsRepository;
        }

        public IViewComponentResult Invoke()
        {
            var cart = cartsRepository.TryGetByUserId(Constants.UserId);
            var cartViewModel = Mapping.ToCartViewModel(cart);
            var cartItemsCount = cartViewModel?.Amount ?? 0;
            return View("CartCount", cartItemsCount);
        }
    }
}
