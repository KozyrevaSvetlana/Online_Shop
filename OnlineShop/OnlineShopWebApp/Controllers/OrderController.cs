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

        public OrderController(IProductsRepository productsRepository, ICartsRepository cartsRepository, IUsersRepository usersRepository)
        {
            this.productsRepository = productsRepository;
            this.cartsRepository = cartsRepository;
            this.usersRepository = usersRepository;
        }
        public IActionResult Index()
        {
            var cart = cartsRepository.TryGetByUserId(Constants.UserId);
            ViewBag.CartItemsCount = cartsRepository.GetAllAmounts(Constants.UserId);
            return View(cart);
        }
        public IActionResult Accept(string name, string surname, string adress, string phone, string email, string comment)
        {
            var cart = cartsRepository.TryGetByUserId(Constants.UserId);
            usersRepository.AddUser(name, surname, adress, phone, email, comment, cart);
            cartsRepository.ClearCart(Constants.UserId);
            return RedirectToAction("Result");
        }

        public IActionResult Result()
        {
            return View();
        }
    }
}
