using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly IFavoritesRepository favoritesRepository;

        public FavoritesController(IProductsRepository productsRepository, IFavoritesRepository favoritesRepository)
        {
            this.productsRepository = productsRepository;
            this.favoritesRepository = favoritesRepository;
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
            var product = productsRepository.GetProductById(id);
            favoritesRepository.DeleteItem(product, Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
