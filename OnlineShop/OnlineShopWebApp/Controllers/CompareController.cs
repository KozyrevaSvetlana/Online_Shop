using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Models.Interfaces;

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
            var compareCart = compareRepository.TryGetByUserId(Constants.UserId);
            return View(compareCart);
        }

        public IActionResult Add(int id)
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
        public IActionResult Delete(int id)
        {
            compareRepository.DeleteItem(id, Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
