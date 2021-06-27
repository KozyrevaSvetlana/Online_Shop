using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Helpers;
using System;

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
        public IActionResult Index()
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;
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

        public IActionResult Add(Guid id)
        {
            var product = productsRepository.GetProductById(id);
            var user = userManager.GetUserAsync(HttpContext.User).Result;
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
        public IActionResult ChangeAmount(Guid id, int sign)
        {
            var product = productsRepository.GetProductById(id);
            var user = userManager.GetUserAsync(HttpContext.User).Result;
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
        public IActionResult Clear()
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;
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
