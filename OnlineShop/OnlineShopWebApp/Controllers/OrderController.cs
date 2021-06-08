using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartsRepository cartsRepository;
        private readonly IOrdersRepository ordersRepository;
        private readonly IUsersRepository usersRepository;

        public OrderController(ICartsRepository cartsRepository, IOrdersRepository ordersWithoutUserRepository,IUsersRepository usersRepository)
        {
            this.cartsRepository = cartsRepository;
            this.ordersRepository = ordersWithoutUserRepository;
            this.usersRepository = usersRepository;
        }
        public IActionResult Index()
        {
            if (Constants.UserId != "UserId")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpPost]
        public IActionResult Accept(OrderViewModel order, UserContactViewModel userContacts)
        {
            var errorsResult = userContacts.IsValid();
            if (errorsResult != null)
            {
                foreach (var error in errorsResult)
                {
                    ModelState.AddModelError("", error);
                }
            }
            if (ModelState.IsValid)
            {
                order.AddContacts(Constants.UserId, userContacts, new InfoStatusOrderViewModel(DateTime.Now));
                var cart = cartsRepository.TryGetByUserId(Constants.UserId);
                ordersRepository.AddOrder(Mapping.ToOrder(order), cart);
                if (Constants.UserId != "UserId")
                {
                    var user = usersRepository.GetUserByName(Constants.UserId);
                    user.Orders.Add(order);
                }
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
