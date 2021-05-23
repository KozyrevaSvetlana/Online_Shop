using Microsoft.AspNetCore.Mvc;
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
            return View(result);
        }
        [HttpPost]
        public ActionResult EditProduct(Product editProduct, int idCategoryItem)
        {
            var categoryResult = categoriesRepository.GetCategoryBySubcategoryId(idCategoryItem);
            var categoryItemResult = categoriesRepository.GetSubcategoryById(idCategoryItem);
            if (categoryResult == null)
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
        public ActionResult AddNewProduct(Product newProduct, int idCategoryItem)
        {
            var errorsResult = newProduct.IsValid();
            if (errorsResult.Count!=0)
            {
                foreach (var error in errorsResult)
                {
                    ModelState.AddModelError("", error);
                }
                ViewBag.Categories = categoriesRepository.AllCategories;
                return View("AddProduct", newProduct);
            }
            if (ModelState.IsValid)
            {
                var categoryResult = categoriesRepository.GetCategoryBySubcategoryId(idCategoryItem);
                var subcategoryResult = categoriesRepository.GetSubcategoryById(idCategoryItem);
                newProduct.Category = categoryResult;
                newProduct.Subcategory = subcategoryResult;
                productsRepository.Add(newProduct);
                return RedirectToAction("Index", "Admin");
            }
            return RedirectToAction("Index", "Admin");
        }
    }
}
