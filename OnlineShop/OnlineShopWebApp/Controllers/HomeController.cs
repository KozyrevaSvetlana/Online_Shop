using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Models.Interfaces;
using System.Diagnostics;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsRepository products;
        private readonly ICategoriesRepository categoriesRepository;

        public HomeController(IProductsRepository products, ICartsRepository cartsRepository, ICategoriesRepository categoriesRepository)
        {
            this.products = products;
            this.categoriesRepository = categoriesRepository;
        }

        public IActionResult Index()
        {
            var allProducts = products.AllProducts;
            AddCategoriesToProductRepository();
            return View(allProducts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        private void AddCategoriesToProductRepository()
        {
            var resultCategoryToys = categoriesRepository.GetCategoryById(1);
            var subcategory1 = categoriesRepository.GetSubcategoryById(1, 3);
            var product1 = products.GetProductById(1);
            product1.AddCategorySubcategory(resultCategoryToys, subcategory1);
            var product2 = products.GetProductById(2);
            var subcategory2 = categoriesRepository.GetSubcategoryById(1, 1);
            product2.AddCategorySubcategory(resultCategoryToys, subcategory2);
            var product3 = products.GetProductById(3);
            var subcategory3 = categoriesRepository.GetSubcategoryById(1, 5);
            product3.AddCategorySubcategory(resultCategoryToys, subcategory3);
            var product4 = products.GetProductById(4);
            var subcategory4 = categoriesRepository.GetSubcategoryById(1, 6);
            product4.AddCategorySubcategory(resultCategoryToys, subcategory4);
            var product5 = products.GetProductById(5);
            var subcategory5 = categoriesRepository.GetSubcategoryById(1, 7);
            product5.AddCategorySubcategory(resultCategoryToys, subcategory5);
        }
    }
}
