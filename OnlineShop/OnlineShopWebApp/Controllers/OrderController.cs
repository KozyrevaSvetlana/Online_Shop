using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
            var userName = Request.Cookies["id"];
            var cart = new Cart();
            if(userName==null)
            {
                cart = cartsRepository.TryGetByUserId(user.UserName);
            }
            else
            {
                cart = cartsRepository.TryGetByUserId(userName);
            }
            return View();
        }
        [HttpPost]
        public IActionResult Accept(string Comment, UserContactViewModel userContacts)
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;
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
                order.AddContacts(user.UserName, userContacts, new InfoStatusOrderViewModel(DateTime.Now), Comment);
                var cart = new Cart();
                cart = cartsRepository.TryGetByUserId(user.UserName);
                if(cart==null)
                {
                    var userName = Request.Cookies["id"];
                    cart = cartsRepository.TryGetByUserId(userName);
                    Response.Cookies.Delete("id");
                }
                order.Products =cart.Items.ToCartItemViewModels();
                order.Number = ordersRepository.CountOrders();
                ordersRepository.AddOrder(order.ToOrder(), cart);
                return RedirectToAction("Result");
            }
            return View("Index");
        }

        public IActionResult Result()
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            var order = ordersRepository.GetLastOrder(user.UserName);
            return View(order.ToOrderViewModels());
        }
    }
}
