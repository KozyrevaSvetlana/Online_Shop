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
        public string Index(string id)
        {
            var idResult = 0;
            try
            {
                if (id != null)
                {
                    idResult = Int32.Parse(id);
                }
                else
                {
                    return "Вы не ввели id товара";
                }
            }
            catch (FormatException)
            {
                return "Ошибка! Вы ввели не число";
            }
            catch (OverflowException)
            {
                return "Ошибка! Вы ввели слишком большое число";
            }
            if (idResult < 1)
            {
                return "Ошибка! Вы ввели слишком число, меньше 1";
            }
            return FindProductById(idResult);
        }

        private static string FindProductById(int idResult)
        {
            StringBuilder results = new StringBuilder();
            var allProducts = AllProductsStoreage.GetAllProducts();
            var result =  allProducts.FirstOrDefault(x => x.Id == idResult);
            if (result == null)
            {
                return "Данный товар не найден";
            }
            return result.IdToString();
        }
    }
}
