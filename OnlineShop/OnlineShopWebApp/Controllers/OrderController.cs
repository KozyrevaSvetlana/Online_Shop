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
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ICartsRepository cartsRepository;
        private readonly IOrdersRepository ordersRepository;
        private readonly UserManager<User> userManager;

        public OrderController(ICartsRepository cartsRepository, IOrdersRepository ordersWithoutUserRepository, UserManager<User> userManager)
        {
            this.userManager = userManager;
            this.cartsRepository = cartsRepository;
            ordersRepository = ordersWithoutUserRepository;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var userName = Request.Cookies["id"];
            var cart = new Cart();
            if(userName==null)
            {
                cart = await cartsRepository.TryGetByUserId(user.UserName);
            }
            else
            {
                cart = await cartsRepository.TryGetByUserId(userName);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AcceptAsync(string Comment, UserContactViewModel userContacts)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
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
                cart = await cartsRepository.TryGetByUserId(user.UserName);
                if(cart==null)
                {
                    var userName = Request.Cookies["id"];
                    cart = await cartsRepository.TryGetByUserId(userName);
                    Response.Cookies.Delete("id");
                }
                order.Products =cart.Items.ToCartItemViewModels();
                order.Number = await ordersRepository.CountOrders();
                ordersRepository.AddOrder(order.ToOrder(), cart);
                return RedirectToAction("Result");
            }
            return View("Index");
        }

        public async Task<IActionResult> ResultAsync()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var order = await ordersRepository.GetLastOrder(user.UserName);
            return View(order.ToOrderViewModels());
        }
    }
}
