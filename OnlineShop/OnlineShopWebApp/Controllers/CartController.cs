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
                cart = cartsRepository.TryGetByUserId(userName);
            }
            else
            {
                cart = cartsRepository.TryGetByUserId(user.UserName);
            }
            return View(cart.ToCartViewModel());
        }

        public async Task<IActionResult> AddAsync(Guid id)
        {
            var product = productsRepository.GetProductById(id);
            var user = await userManager.GetUserAsync(HttpContext.User);
            if(user==null)
            {
                var cookieValue = Request.Cookies["id"];
                if(cookieValue == null)
                {
                    cookieValue = Guid.NewGuid().ToString()+DateTime.Now.ToString("d");
                    CookieOptions cookie = new CookieOptions();
                    cookie.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Append("id", cookieValue, cookie);
                }
                cartsRepository.Add(product, cookieValue);
            }
            else
            {
                cartsRepository.Add(product, user.UserName);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> ChangeAmountAsync(Guid id, int sign)
        {
            var product = productsRepository.GetProductById(id);
            var user = await userManager.GetUserAsync(HttpContext.User);
            if (user==null)
            {
                var userName = Request.Cookies["id"];
                cartsRepository.ChangeAmount(product, sign, userName);
            }
            else
            {
                cartsRepository.ChangeAmount(product, sign, user.UserName);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> ClearAsync()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            if (user==null)
            {
                var userName = Request.Cookies["id"];
                cartsRepository.ClearCart(userName);
            }
            else
            {
                cartsRepository.ClearCart(user.UserName);
            }

            return RedirectToAction("Index");
        }
    }
}
