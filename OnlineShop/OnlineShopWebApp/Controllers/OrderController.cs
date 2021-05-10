using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Models.Interfaces;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartsRepository cartsRepository;
        private readonly IOrdersRepository ordersRepository;

        public OrderController(ICartsRepository cartsRepository, IOrdersRepository ordersWithoutUserRepository)
        {
            this.cartsRepository = cartsRepository;
            this.ordersRepository = ordersWithoutUserRepository;
        }
        public IActionResult Index()
        {
            var cart = cartsRepository.TryGetByUserId(Constants.UserId);
            return View(cart);
        }
        [HttpPost]
        public IActionResult Accept(Order order, UserContact user)
        {
            var cart = cartsRepository.TryGetByUserId(Constants.UserId);
            order.AddContacts(Constants.UserId, user);
            order.AddCart(cart);
            ordersRepository.AddOrder(order);
            return RedirectToAction("Result");
        }

        public IActionResult Result()
        {
            var order = ordersRepository.GetLastOrder(Constants.UserId);
            return View(order);
        }
    }
}
