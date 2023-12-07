using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelsLibrary.Helper;
using ModelsLibrary.ModelsDto;
using ModelsLibrary.ModelsVM;
using Nelibur.ObjectMapper;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Helpers;
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
            return View(products.Select(p=> TinyMapper.Map<ProductViewModel>(p)));
        }

        public async Task<IActionResult> Description(Guid id)
        {
            var result = await productsRepository.GetByIdAsync(id);
            var product = TinyMapper.Map<ProductViewModel>(result);
            return View(product);
        }

        public async Task<IActionResult> EditForm(Guid id)
        {
            var result = await productsRepository.GetByIdAsync(id);
            return View(TinyMapper.Map<ProductViewModel>(result));
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
                var productDB = TinyMapper.Map<Product>(editProduct);
                await productsRepository.EditAsync(productDB);
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
                    return View("Index", products.Select(x=> TinyMapper.Map<ProductViewModel>(x)));
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
                var product = newProduct.ToProduct(imagesPaths);
                await productsRepository.CreateAsync(product);
                return RedirectToAction("Index");
            }
            return View("AddProduct", newProduct);
        }
    }
}
