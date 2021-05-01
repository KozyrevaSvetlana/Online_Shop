using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class ComparesController : Controller
    {
        private readonly ProductsRepository productRepository;
        public ComparesController()
        {
            productRepository = new ProductsRepository();
        }
        public IActionResult Index()
        {
            var cart = CompareList.GetCompareList();
            СountTheAmount();
            return View(cart);
        }

        public IActionResult Add(int productId)
        {
            var product = productRepository.TryGetById(productId);
            CompareList.Add(product);
            return RedirectToAction("Index");
        }
        public IActionResult Clear(int productId)
        {
            CompareList.Clear();
            return RedirectToAction("Index");
        }
        public void СountTheAmount()
        {
            var count = CartsRepository.GetAllAmounts(Constants.UserId);
            ViewBag.Int = count;
        }
    }
}
