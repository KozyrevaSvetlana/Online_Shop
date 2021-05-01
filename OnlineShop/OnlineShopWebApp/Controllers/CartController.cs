using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ProductsRepository productRepository;
        public CartController()
        {
            productRepository = new ProductsRepository();
        }
        public IActionResult Index()
        {
            var cart = CartsRepository.TryGetByUserId(Constants.UserId);
            return View(cart);
        }

        public IActionResult Add(int productId)
        {
            var product = productRepository.TryGetById(productId);
            CartsRepository.Add(product, Constants.UserId);
            return RedirectToAction("Index");
        }


        public IActionResult СountTheAmount()
        {
            //проверка как работает
            var model = 10;
            ViewBag.Int = model;
            return PartialView(model);
        }
    }
}
