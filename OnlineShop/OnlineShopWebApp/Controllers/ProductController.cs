﻿using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
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
            return FindProductById(idResult);
        }

        private static string FindProductById(int idResult)
        {
            StringBuilder results = new StringBuilder();
            var allProducts = new List<Product>();
            allProducts = AllProductsStoreage.GetAll();
            foreach (var product in allProducts)
            {
                if (product.Id == idResult)
                {
                    results.Append(product + "\n");
                    results.Append("");
                }
            }
            if (results.Length != 0)
            {
                return results.ToString();
            }
            else
            {
                return "Данный товар не найден";
            }
        }
    }
}
