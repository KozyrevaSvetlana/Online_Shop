using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ProductsRepository productRepository;
        public CartController(ProductsRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public IActionResult Index()
        {
            var cart = CartsRepository.TryGetByUserId(Constants.UserId);
            ViewBag.AllAmountAtCart = CartsRepository.GetAllAmounts(Constants.UserId);
            return View(cart);
        }

        public IActionResult Add(int productId)
        {
            var product = productRepository.TryGetById(productId);
            CartsRepository.Add(product, Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
