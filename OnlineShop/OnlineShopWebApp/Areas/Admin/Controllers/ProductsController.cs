using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Helper;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System;
using System.Linq;
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

        public ProductsController(IProductsRepository productsRepository, ImagesProvider imagesProvider, IOrdersRepository ordersRepository)
        {
            this.productsRepository = productsRepository;
            this.imagesProvider = imagesProvider;
            this.ordersRepository = ordersRepository;
        }

        public async Task<IActionResult> Index()
        {
            var products = await productsRepository.GetAllAsync();
            return View(products.ToProductViewModels());
        }

        public async Task<IActionResult> Description(Guid id)
        {
            var result = await productsRepository.GetByIdAsync(id);
            return View(result.ToProductViewModel());
        }

        public async Task<IActionResult> EditForm(Guid id)
        {
            var result = await productsRepository.GetByIdAsync(id);
            return View(result.ToProductViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(ProductViewModel editProduct)
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
                await productsRepository.EditAsync(editProduct.ToProduct(imagesPaths));
                return RedirectToAction("Index");
            }
            return View("EditForm", editProduct);
        }

        public async Task<IActionResult> DeleteProduct(Guid id)      
        {
            if (!await ordersRepository.IsInOrder(id))
            {
                await productsRepository.DeleteAsync(id);
            }
            else
            {
                var result = await ordersRepository.GetOrders(id);
                if(result != null && result.Any())
                {
                    string ordersNumbers = "";
                    foreach (var order in result)
                    {
                        ordersNumbers += order.Number + ", ";
                    }
                    ModelState.AddModelError("", $"Невозможно удалить товар, он есть в заказах: {ordersNumbers.Substring(0, ordersNumbers.Length - 2)}");
                    var products = await productsRepository.GetAllAsync();
                    return View("Index", products.ToProductViewModels());
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewProduct(AddProductViewModel newProduct)
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

                await productsRepository.CreateAsync(newProduct.ToProduct(imagesPaths));
                return RedirectToAction("Index");
            }
            return View("AddProduct", newProduct);
        }
    }
}
