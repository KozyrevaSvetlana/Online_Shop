using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class SearchController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly ISearchRepository seachRepository;

        public SearchController(IProductsRepository productsRepository, ISearchRepository seachRepository)
        {
            this.productsRepository = productsRepository;
            this.seachRepository = seachRepository;
        }
        public IActionResult Index()
        {
            var seach = seachRepository.TryGetByUserId(Constants.UserId);
            return View(seach);
        }

        [HttpPost]
        public IActionResult Accept(string result)
        {
            seachRepository.Clear(Constants.UserId);
            if (result!=null && result.Length>2)
            {
                TempData["Result"] = result;
                seachRepository.Add(productsRepository.SeachProduct(result.Split()), Constants.UserId);
            }
            return RedirectToAction("Index");
        }
    }
}
