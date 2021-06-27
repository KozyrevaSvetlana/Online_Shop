using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System;
using System.IO;
using System.Linq;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class ProductsController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly IWebHostEnvironment appEnvironment;

        public ProductsController(IProductsRepository products, IWebHostEnvironment appEnvironment)
        {
            productsRepository = products;
            this.appEnvironment = appEnvironment;
        }
        public IActionResult Index()
        {
            return View(productsRepository.AllProducts.ToProductViewModels());
        }
        public IActionResult Description(Guid id)
        {
            var result = productsRepository.GetProductById(id);
            return View(result.ToProductViewModel());
        }
        public ActionResult EditForm(Guid id)
        {
            var result = productsRepository.GetProductById(id);
            return View(result.ToProductViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
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
                    Id= editProduct.Id,
                    Name = editProduct.Name,
                    Cost = editProduct.Cost,
                    Description = editProduct.Description,
                    Image = editProduct.Image
                };
                if (editProduct.UploadedFile != null)
                {
                    string productImagesPath = Path.Combine(appEnvironment.WebRootPath + "/img/Products/");
                    var fileName = Guid.NewGuid() + "." + editProduct.UploadedFile.FileName.Split('.').Last();
                    using (var fileStream = new FileStream(productImagesPath + fileName, FileMode.Create))
                    {
                        editProduct.UploadedFile.CopyTo(fileStream);
                    }
                    productDb.Image = "/img/Products/" + fileName;
                }
                productsRepository.Edit(productDb);
                return RedirectToAction("Index");
            }
            return View("EditForm", editProduct);
        }
        public ActionResult DeleteProduct(Guid id)
        {
            //productsRepository.DeleteItem(id);
            return RedirectToAction("Index");
        }
        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
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
                string fileName = "";
                if (newProduct.UploadedFile != null)
                {
                    string productImagesPath = Path.Combine(appEnvironment.WebRootPath + "/img/Products/");
                    if (!Directory.Exists(productImagesPath))
                    {
                        Directory.CreateDirectory(productImagesPath);
                    }

                    fileName = Guid.NewGuid() + "." + newProduct.UploadedFile.FileName.Split('.').Last();
                    using (var fileStream = new FileStream(productImagesPath + fileName, FileMode.Create))
                    {
                        newProduct.UploadedFile.CopyTo(fileStream);
                    }
                }
                var productDb = new Product
                {
                    Name = newProduct.Name,
                    Cost = newProduct.Cost,
                    Description = newProduct.Description,
                    Image = "/img/Products/" + fileName
                };
                productsRepository.Add(productDb);
                return RedirectToAction("Index");
            }
            return View("AddProduct", newProduct);
        }
    }
}
