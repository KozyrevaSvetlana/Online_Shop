using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Helpers;
using System;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly ICartsRepository cartsRepository;
        private readonly UserManager<User> userManager;

        public CartController(IProductsRepository productsRepository, ICartsRepository cartsRepository, UserManager<User> userManager)
        {
            this.productsRepository = productsRepository;
            this.cartsRepository = cartsRepository;
            this.userManager = userManager;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var cart = new Cart();
            if (user == null)
            {
                var userName = Request.Cookies["id"];
                cart = await cartsRepository.TryGetByUserId(userName);
            }
            else
            {
                cart = await cartsRepository.TryGetByUserId(user.UserName);
            }
            return View(cart.ToCartViewModel());
        }

        public async Task<IActionResult> AddAsync(System.Guid id)
        {
            var product = await productsRepository.GetById(id);
            var user = await userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                var cookieValue = Request.Cookies["id"];
                if (cookieValue == null)
                {
                    cookieValue = System.Guid.NewGuid().ToString() + DateTime.Now.ToString("d");
                    CookieOptions cookie = new CookieOptions();
                    cookie.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Append("id", cookieValue, cookie);
                }
                await cartsRepository.Add(product, cookieValue);
            }
            else
            {
                await cartsRepository.Add(product, user.UserName);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> ChangeAmountAsync(System.Guid id, int sign)
        {
            var product = await productsRepository.GetById(id);
            var user = await userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                var userName = Request.Cookies["id"];
                await cartsRepository.ChangeAmount(product, sign, userName);
            }
            else
            {
                await cartsRepository.ChangeAmount(product, sign, user.UserName);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> ClearAsync()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                var userName = Request.Cookies["id"];
                await cartsRepository.Clear(userName);
            }
            else
            {
                await cartsRepository.Clear(user.UserName);
            }

            return RedirectToAction("Index");
        }
    }
}
