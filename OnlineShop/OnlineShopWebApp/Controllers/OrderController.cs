using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Models.Interfaces;
using System;

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
            return View();
        }
        [HttpPost]
        public IActionResult Accept(Order order, UserContact user)
        {
            var errorsResult = user.IsValid();
            if (errorsResult != null)
            {
                foreach (var error in errorsResult)
                {
                    ModelState.AddModelError("", error);
                }
            }
            if (ModelState.IsValid)
            {
                order.AddContacts(Constants.UserId, user, new InfoStatusOrder(DateTime.Now));
                ordersRepository.AddOrder(order, cartsRepository.TryGetByUserId(Constants.UserId));
                cartsRepository.ClearCart(Constants.UserId);
                return RedirectToAction("Result");
            }
            return View("Index");
        }

        public IActionResult Result()
        {
            var order = ordersRepository.GetLastOrder(Constants.UserId);
            return View(order);
        }
    }
}
