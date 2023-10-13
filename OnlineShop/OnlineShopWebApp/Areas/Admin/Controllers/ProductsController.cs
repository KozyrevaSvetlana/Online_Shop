using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Helper;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class ProductsController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly ImagesProvider imagesProvider;
        private readonly IOrdersRepository ordersRepository;
        private readonly ICartsRepository cartsRepository;

        public ProductsController(IProductsRepository productsRepository, ImagesProvider imagesProvider, IOrdersRepository ordersRepository, ICartsRepository cartsRepository)
        {
            this.productsRepository = productsRepository;
            this.imagesProvider = imagesProvider;
            this.ordersRepository = ordersRepository;
            this.cartsRepository = cartsRepository;
        }
        public async Task<IActionResult> Index()
        {
            var products = await productsRepository.GetAll();
            return View(products.ToProductViewModels());
        }
        public async Task<IActionResult> Description(Guid id)
        {
            var result = await productsRepository.GetById(id);
            return View(result.ToProductViewModel());
        }
        public async Task<IActionResult> EditForm(Guid id)
        {
            var result = await productsRepository.GetById(id);
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
                var imagesPaths = imagesProvider.SafeFiles(editProduct.UploadedFile, ImageFolders.Products);
                productsRepository.Edit(editProduct.ToProduct(imagesPaths));
                return RedirectToAction("Index");
            }
            return View("EditForm", editProduct);
        }
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            if (!await ordersRepository.IsInOrder(id))
            {
                await productsRepository.Delete(id);
            }
            else
            {
                var result = await ordersRepository.GetProductInOrders(id);
                string ordersNumbers = "";
                foreach (var order in result)
                {
                    ordersNumbers += order.Number + ", ";
                }
                ModelState.AddModelError("", $"Невозможно удалить товар, он есть в заказах: {ordersNumbers.Substring(0, ordersNumbers.Length - 2)}");
                var products = await productsRepository.GetAll();
                return View("Index", products.ToProductViewModels());
            }
            return RedirectToAction("Index");
        }
        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNewProduct(AddProductViewModel newProduct)
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
                var imagesPaths = imagesProvider.SafeFiles(newProduct.UploadedFiles, ImageFolders.Products);

                productsRepository.Add(newProduct.ToProduct(imagesPaths));
                return RedirectToAction("Index");
            }
            return View("AddProduct", newProduct);
        }
    }
}
