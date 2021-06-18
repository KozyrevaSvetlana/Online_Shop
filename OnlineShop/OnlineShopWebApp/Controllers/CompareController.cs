using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Helpers;
using System;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class CompareController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly ICompareRepository compareRepository;
        private readonly UserManager<User> userManager;

        public CompareController(IProductsRepository productsRepository, ICompareRepository compareRepository, UserManager<User> userManager)
        {
            this.productsRepository = productsRepository;
            this.compareRepository = compareRepository;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            var compareCart = compareRepository.TryGetByCompareId(user.UserName);
            return View(compareCart.ToCompareViewModel());
        }

        public IActionResult Add(Guid id)
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            var product = productsRepository.GetProductById(id);
            compareRepository.Add(product, user.UserName);
            return RedirectToAction("Index");
        }
        public IActionResult Clear()
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            compareRepository.Clear(user.UserName);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(Guid id)
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            compareRepository.DeleteItem(id, user.UserName);
            return RedirectToAction("Index");
        }
    }
}
