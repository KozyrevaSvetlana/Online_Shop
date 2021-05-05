using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Models.Interfaces;

namespace OnlineShopWebApp.Controllers
{
    public class ComparesController : Controller
    {
        private readonly ProductsRepository productsRepository;
        private readonly ICartsRepository cartsRepository;
        private readonly IComparesList comparesList;

        public ComparesController(ProductsRepository productsRepository, ICartsRepository cartsRepository, IComparesList comparesList)
        {
            this.productsRepository = productsRepository;
            this.cartsRepository = cartsRepository;
            this.comparesList = comparesList;
        }
        public IActionResult Index()
        {
            var cart = comparesList._comparesList;
            ViewBag.CartItemsCount = cartsRepository.GetAllAmounts(Constants.UserId);
            return View(cart);
        }

        public IActionResult Add(int id)
        {
            var product = productsRepository.GetProductById(id);
            comparesList.Add(product);
            return RedirectToAction("Index");
        }
        public IActionResult Clear()
        {
            comparesList.Clear();
            return RedirectToAction("Index");
        }
    }
}
