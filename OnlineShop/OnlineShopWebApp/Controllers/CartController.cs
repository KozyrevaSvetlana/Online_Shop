using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ModelsLibrary.ModelsDto;
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
            var cart = await cartsRepository.GetByIdAsync(null, user?.UserName ?? Request.Cookies["id"]);
            return View(cart.ToCartViewModel());
        }

        public async Task<IActionResult> AddAsync(Guid id)
        {
            var product = await productsRepository.GetByIdAsync(id);
            var user = await userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                var cookieValue = Request.Cookies["id"];
                if (cookieValue == null)
                {
                    cookieValue = Guid.NewGuid().ToString() + DateTime.Now.ToString("d");
                    var cookie = new CookieOptions();
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
        public async Task<IActionResult> ChangeAmountAsync(Guid id, int sign)
        {
            var product = await productsRepository.GetByIdAsync(id);
            var user = await userManager.GetUserAsync(HttpContext.User);
            await cartsRepository.ChangeAmountAsync(product, sign, user?.UserName ?? Request.Cookies["id"]);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> ClearAsync()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            await cartsRepository.ClearAsync(user?.UserName ?? Request.Cookies["id"]);
            return RedirectToAction("Index");
        }
    }
}
