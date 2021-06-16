using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ICartsRepository cartsRepository;
        private readonly IOrdersRepository ordersRepository;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public OrderController(ICartsRepository cartsRepository, IOrdersRepository ordersWithoutUserRepository, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.cartsRepository = cartsRepository;
            ordersRepository = ordersWithoutUserRepository;
        }
        public IActionResult Index()
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            var cart = cartsRepository.TryGetById(user.UserName);
            ViewBag.Cart = Mapping.ToCartItemViewModels(cart.Items);
            return View();
        }
        [HttpPost]
        public IActionResult Accept(string Comment, UserContactViewModel userContacts)
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
                var order = new OrderViewModel();
                order.AddContacts(Constants.UserId, userContacts, new InfoStatusOrderViewModel(DateTime.Now), Comment);
                var cart = cartsRepository.TryGetById(Constants.UserId);
                order.Products = Mapping.ToCartItemViewModels(cart.Items);
                order.Number = ordersRepository.CountOrders();
                ordersRepository.AddOrder(Mapping.ToOrder(order), cart);
                //if (Constants.UserId != "UserId")
                //{
                //    var user = usersRepository.GetUserByName(Constants.UserId);
                //    user.Orders.Add(order);
                //}
                return RedirectToAction("Result");
            }
            return View("Index");
        }

        public IActionResult Result()
        {
            var order = ordersRepository.GetLastOrder(Constants.UserId);
            return View(Mapping.ToOrderViewModels(order));
        }
    }
}
