using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
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
        private readonly SignInManager<User> signInManager;

        public CompareController(IProductsRepository productsRepository,  ICompareRepository compareRepository, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.productsRepository = productsRepository;
            this.compareRepository = compareRepository;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            var compareCart = compareRepository.TryGetByCompareId(user.UserName);
            return View(Mapping.ToCompareViewModel(compareCart));
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
