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
            var compareCart = await compareRepository.GetByIdAsync(null, user.UserName);
            return View(compareCart.ToCompareViewModel());
        }

        public async Task<IActionResult> AddAsync(System.Guid id)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var product = await productsRepository.GetByIdAsync(id);
            await compareRepository.AddAsync(product.Id, user.UserName);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> ClearAsync()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            await compareRepository.ClearAsync(user.UserName);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteAsync(System.Guid id)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            await compareRepository.DeleteAsync(id, user.UserName);
            return RedirectToAction("Index");
        }
    }
}
