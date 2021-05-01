using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class СompareController : Controller
    {
        private readonly ProductsRepository productRepository;
        public СompareController()
        {
            productRepository = new ProductsRepository();
        }

        public IActionResult Index()
        {
            var cart = CompareList.GetCompareList();
            return View(cart);
        }

        public IActionResult Add(int productId)
        {
            var product = productRepository.TryGetById(productId);
            CompareList.Add(product);
            return RedirectToAction("Index");
        }
    }
}
