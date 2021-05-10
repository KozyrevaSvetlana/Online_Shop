using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Models.Interfaces;

namespace OnlineShopWebApp.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly IFavoritesRepository favoritesRepository;
        private readonly ICartsRepository cartsRepository;

        public FavoritesController(IProductsRepository productsRepository, IFavoritesRepository favoritesRepository, ICartsRepository cartsRepository)
        {
            this.productsRepository = productsRepository;
            this.favoritesRepository = favoritesRepository;
            this.cartsRepository = cartsRepository;
        }
        public IActionResult Index()
        {
            var cart = favoritesRepository.TryGetByUserId(Constants.UserId);
            return View(cart);
        }

        public IActionResult Add(int id)
        {
            var product = productsRepository.GetProductById(id);
            favoritesRepository.Add(product, Constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult Clear()
        {
            favoritesRepository.Clear(Constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            favoritesRepository.DeleteItem(id, Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
