using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Models.Interfaces;

namespace OnlineShopWebApp.Controllers
{
    public class СompareController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly ICartsRepository cartsRepository;
        private readonly ICompareList comparesList;

        public СompareController(IProductsRepository productsRepository, ICartsRepository cartsRepository, ICompareList comparesList)
        {
            this.productsRepository = productsRepository;
            this.cartsRepository = cartsRepository;
            this.comparesList = comparesList;
        }

        public IActionResult Index()
        {
            var cart = comparesList.AllCompareList;
            ViewBag.CartItemsCount = cartsRepository.GetAllAmounts(Constants.UserId);
            return View(cart);
        }
        public IActionResult Add(int id)
        {
            var product = productsRepository.GetProductById(id);
            comparesList.Add(product);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var product = productsRepository.GetProductById(id);
            comparesList.Delete(product);
            return RedirectToAction("Index");
        }

    }
}
