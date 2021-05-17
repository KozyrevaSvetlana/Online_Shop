using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class SeachController : Controller
    {
        private readonly IProductsRepository productsRepository;

        public SeachController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Accept(string result)
        {
            TempData["Result"] = result;
            string[] results = result.Split();
            return RedirectToAction("Index");
        }
    }
}
