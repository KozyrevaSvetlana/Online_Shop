using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
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
            var cart = compareRepository.TryGetByUserId(Constants.UserId);
            return View(cart.Items);
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
            var product = productsRepository.GetProductById(id);
            compareRepository.DeleteItem(product, Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
