using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Models.Interfaces;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly ICartsRepository cartsRepository;
        private readonly IUsersRepository usersRepository;
        private readonly IOrdersWithoutUserRepository ordersWithoutUserRepository;

        public OrderController(IProductsRepository productsRepository, ICartsRepository cartsRepository, IUsersRepository usersRepository, IOrdersWithoutUserRepository ordersWithoutUserRepository)
        {
            this.productsRepository = productsRepository;
            this.cartsRepository = cartsRepository;
            this.usersRepository = usersRepository;
            this.ordersWithoutUserRepository = ordersWithoutUserRepository;
        }
        public IActionResult Index()
        {
            var cart = cartsRepository.TryGetByUserId(Constants.UserId);
            return View(cart);
        }
        [HttpPost]
        public IActionResult Accept(OrderWithoutUser orderWithoutUser)
        {
            var cart = cartsRepository.TryGetByUserId(Constants.UserId);
            ordersWithoutUserRepository.AddOrder(orderWithoutUser, cart, Constants.UserId);
            return RedirectToAction("Result");
        }

        public IActionResult Result()
        {
            var order = ordersWithoutUserRepository.GetLastOrder(Constants.UserId);
            return View(order);
        }
    }
}
