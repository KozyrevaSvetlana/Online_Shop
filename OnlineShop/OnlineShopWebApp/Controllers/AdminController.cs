﻿using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly ICategoriesRepository categoriesRepository;

        public AdminController(IProductsRepository products, ICategoriesRepository categoriesRepository)
        {
            this.productsRepository = products;
            this.categoriesRepository = categoriesRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Description(int id)
        {
            var result = productsRepository.GetProductById(id);
            return View(result);
        }
        public ActionResult EditForm(int id)
        {
            var result = productsRepository.GetProductById(id);
            ViewBag.Categories = categoriesRepository.AllCategories;
            ViewBag.Subcategories = result.Subcategory;
            return View(result);
        }
        [HttpPost]
        public ActionResult EditProduct(Product editProduct, int idCategory, int idCategoryItem)
        {
            var categoryResult = categoriesRepository.GetCategoryById(idCategory);
            var categoryItemResult = categoriesRepository.GetSubcategoryById(categoryResult.Id,idCategoryItem);
            if (categoryResult == null || idCategory==0)
            {
                ModelState.AddModelError("", "Выберите верную категорию товара");
            }
            if (categoryItemResult == null|| idCategoryItem==0)
            {
                ModelState.AddModelError("", "Выберите верную подкатегорию товара");
            }
            editProduct.Category = categoryResult;
            editProduct.Subcategory = categoryItemResult;
            var validResult = editProduct.IsValid();
            if (validResult != null)
            {
                foreach (var errors in validResult)
                {
                    ModelState.AddModelError("", errors);
                }
            }
            productsRepository.Edit(editProduct);
            return RedirectToAction("Index", "Admin");
        }
        public ActionResult DeleteProduct(int id)
        {
            productsRepository.DeleteItem(id);
            return RedirectToAction("Index", "Admin");
        }
        public ActionResult AddProduct()
        {
            ViewBag.Categories = categoriesRepository.AllCategories;
            return View();
        }
        [HttpPost]
        public ActionResult AddNewProduct(Product newProduct, int idCategory, int idCategoryItem)
        {
            if (newProduct.Name == newProduct.Description)
            {
                ModelState.AddModelError("", "Название и опасание товара не должны совпадать");
            }
            else
            {
                var categoryResult = categoriesRepository.GetCategoryById(idCategoryItem);
                var subcategoryResult = categoriesRepository.GetSubcategoryById(idCategory, idCategoryItem);
                newProduct.Category = categoryResult;
                newProduct.Subcategory = subcategoryResult;
                productsRepository.Add(newProduct);
                return RedirectToAction("Index", "Admin");
            }
            return RedirectToAction("AddProduct", "Admin");
        }

    }
}
