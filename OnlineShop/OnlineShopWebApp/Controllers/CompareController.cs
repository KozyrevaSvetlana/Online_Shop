using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Helpers;
using System;
using System.Threading.Tasks;

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
        public async Task<IActionResult> IndexAsync()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var compareCart = await compareRepository.TryGetByCompareId(user.UserName);
            return View(compareCart.ToCompareViewModel());
        }

        public async Task<IActionResult> AddAsync(Guid id)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var product = await productsRepository.GetProductById(id);
            await compareRepository.Add(product, user.UserName);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> ClearAsync()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            await compareRepository.Clear(user.UserName);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            await compareRepository.DeleteItem(id, user.UserName);
            return RedirectToAction("Index");
        }
    }
}
