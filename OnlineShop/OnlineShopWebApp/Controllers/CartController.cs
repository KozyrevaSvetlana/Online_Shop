using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Models.Interfaces;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly ICartsRepository cartsRepository;

        public CartController(IProductsRepository productsRepository, ICartsRepository cartsRepository)
        {
            this.productsRepository = productsRepository;
            this.cartsRepository = cartsRepository;
        }
        public IActionResult Index()
        {
            var cart = cartsRepository.TryGetByUserId(Constants.UserId);
            ViewBag.CartItemsCount = cartsRepository.GetAllAmounts(Constants.UserId);
            return View(cart);
        }

        public IActionResult Add(int id)
        {
            var product = productsRepository.GetProductById(id);
            cartsRepository.Add(product, Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
