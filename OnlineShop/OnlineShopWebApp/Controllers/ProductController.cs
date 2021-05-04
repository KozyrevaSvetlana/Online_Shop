using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct products;

        public ProductController(IProduct product)
        {
            products = product;
        }

        public IActionResult Index(int id)
        {
            var result = FindProductById(id);
            //ViewBag.CartItemsCount = CartsRepository.GetAllAmounts(Constants.UserId);
            return View(result);
        }

        private Product FindProductById(int idResult)
        {
            var allProducts = products.AllProducts;

            var result =  allProducts.FirstOrDefault(x => x.Id == idResult);
            return result;
        }
        private bool IsValid (string id)
        {
            if (id == null)
            {
                return false;
            }
            for (int i = 0; i < id.Length; i++)
            {
                if (!char.IsDigit(id[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
