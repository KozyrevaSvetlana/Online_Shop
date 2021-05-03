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
        private readonly ProductsRepository productsRepository;

        public ComparesController(ProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }
        public IActionResult Index()
        {
            var cart = CompareList.GetCompareList();
            ViewBag.AllAmountAtCart = CartsRepository.GetAllAmounts(Constants.UserId);
            return View(cart);
        }

        public IActionResult Add(int productId)
        {
            var product = productsRepository.TryGetById(productId);
            CompareList.Add(product);
            return RedirectToAction("Index");
        }
        public IActionResult Clear(int productId)
        {
            CompareList.Clear();
            return RedirectToAction("Index");
        }
    }
}
