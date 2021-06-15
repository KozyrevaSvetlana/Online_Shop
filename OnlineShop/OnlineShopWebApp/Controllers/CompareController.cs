using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
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

        public CompareController(IProductsRepository productsRepository,  ICompareRepository compareRepository)
        {
            this.productsRepository = productsRepository;
            this.compareRepository = compareRepository;
        }
        public IActionResult Index()
        {
            var compareCart = compareRepository.TryGetByCompareId(Constants.UserId);
            return View(Mapping.ToCompareViewModel(compareCart));
        }

        public IActionResult Add(Guid id)
        {
            var product = productsRepository.GetProductById(id);
            compareRepository.Add(product, Constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult Clear()
        {
            compareRepository.Clear(Constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(Guid id)
        {
            compareRepository.DeleteItem(id, Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
