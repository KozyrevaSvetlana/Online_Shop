using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models.Interfaces;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class CompareController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly ICompareRepository compareRepository;
        private readonly ICartsRepository cartsRepository;

        public CompareController(IProductsRepository productsRepository,  ICompareRepository compareRepository, ICartsRepository cartsRepository)
        {
            this.productsRepository = productsRepository;
            this.compareRepository = compareRepository;
            this.cartsRepository = cartsRepository;
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
