using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
            if (userName == null)
            {
                cart = await cartsRepository.GetByUserIdAsync(user.UserName);
            }
            else
            {
                cart = await cartsRepository.GetByUserIdAsync(userName);
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
                cart = await cartsRepository.GetByUserIdAsync(user.UserName);
                if (cart == null)
                {
                    var userName = Request.Cookies["id"];
                    cart = await cartsRepository.GetByUserIdAsync(userName);
                    Response.Cookies.Delete("id");
                }
                order.Products = cart.Items.ToCartItemViewModels();
                order.Number = await ordersRepository.GetCountAsync();
                await ordersRepository.AddAsync(cart.Id, order.UserId);
                return RedirectToAction("Result");
            }
            return View("Index");
        }

        public async Task<IActionResult> ResultAsync()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var order = await ordersRepository.GetLast(user.UserName);
            return View(order.ToOrderViewModels());
        }
    }
}
