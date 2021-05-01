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
        // GET: ProductController
        public IActionResult Index(int id)
        {
            var result = FindProductById(id);
            return View(result);
        }

        private Product FindProductById(int idResult)
        {
            var allProducts = ProductsRepository.GetAll();

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
