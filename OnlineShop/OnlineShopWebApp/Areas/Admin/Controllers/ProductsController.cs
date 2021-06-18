using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class ProductsController : Controller
    {
        private readonly IProductsRepository productsRepository;

        public ProductsController(IProductsRepository products)
        {
            productsRepository = products;
        }
        public IActionResult Index()
        {
            return View(Mapping.ToProductViewModels(productsRepository.AllProducts));
        }
        public IActionResult Description(Guid id)
        {
            var result = productsRepository.GetProductById(id);
            return View(Mapping.ToProductViewModel(result));
        }
        public ActionResult EditForm(Guid id)
        {
            var result = productsRepository.GetProductById(id);
            return View(Mapping.ToProductViewModel(result));
        }
        [HttpPost]
        public ActionResult EditProduct(ProductViewModel editProduct)
        {
            var validResult = editProduct.IsValid();
            if (validResult.Count != 0)
            {
                foreach (var errors in validResult)
                {
                    ModelState.AddModelError("", errors);
                }
            }
            if (ModelState.IsValid)
            {
                var productDb = new Product
                {
                    Name = editProduct.Name,
                    Cost = editProduct.Cost,
                    Description = editProduct.Description,
                    Image = editProduct.Image
                };
                productsRepository.Edit(productDb);
                return RedirectToAction("Products", "Admin");
            }
            return View("EditForm", editProduct);
        }
        public ActionResult DeleteProduct(Guid id)
        {
            //productsRepository.DeleteItem(id);
            return RedirectToAction("Products", "Admin");
        }
        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewProduct(ProductViewModel newProduct)
        {
            var errorsResult = newProduct.IsValid();
            if (errorsResult.Count != 0)
            {
                foreach (var error in errorsResult)
                {
                    ModelState.AddModelError("", error);
                }
                return View("AddProduct", newProduct);
            }
            if (ModelState.IsValid)
            {
                var productDb = new Product
                {
                    Name = newProduct.Name,
                    Cost = newProduct.Cost,
                    Description = newProduct.Description,
                    Image = newProduct.Image
                };
                productsRepository.Add(productDb);
                return RedirectToAction("Products", "Admin");
            }
            return RedirectToAction("Products", "Admin");
        }
    }
}
