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
            bool validResult = IsValid(id);
            if (validResult)
            {
                try
                {
                    idResult = Int32.Parse(id);
                }
                catch(OverflowException)
                {
                    return "Вы ввели слишком длинное число";
                }
            }
            else
            {
                return ErrorOutput(id);
            }
            return FindProductById(idResult);
        }

        private string ErrorOutput(string id)
        {
            var result = 0;
            try
            {
                if (id != null)
                {
                    result = Int32.Parse(id);
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
            if (result < 1)
            {
                return "Ошибка! Вы ввели слишком число, меньше 1";
            }
            return "Неизвестная ошибка";
        }

        private static string FindProductById(int idResult)
        {
            StringBuilder results = new StringBuilder();
            var allProducts = ProductsStorage.GetAllProducts();
            var result =  allProducts.FirstOrDefault(x => x.Id == idResult);
            if (result == null)
            {
                return "Данный товар не найден";
            }
            return result.IdToString();
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
