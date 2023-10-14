﻿using Microsoft.AspNetCore.Http;
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
                var userId = Request.Cookies["id"];
                cart = await cartsRepository.GetByIdAsync(null, userId);
            }
            else
            {
                cart = await cartsRepository.GetByIdAsync(null, user.UserName); 
            }
            return View(cart.ToCartViewModel());
        }

        public async Task<IActionResult> AddAsync(System.Guid id)
        {
            var product = await productsRepository.GetByIdAsync(id);
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
                await cartsRepository.AddAsync(product.Id, cookieValue);
            }
            else
            {
                await cartsRepository.AddAsync(product.Id, user.UserName);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> ChangeAmountAsync(System.Guid id, int sign)
        {
            var product = await productsRepository.GetByIdAsync(id);
            var user = await userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                var userId = Request.Cookies["id"];
                await cartsRepository.ChangeAmount(product, sign, userId);
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
                var userId = Request.Cookies["id"];
                await cartsRepository.DeleteAsync(null, userId);
            }
            else
            {
                await cartsRepository.DeleteAsync(null,user.Id);
            }

            return RedirectToAction("Index");
        }
    }
}
