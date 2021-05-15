using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductsRepository products;

        public AdminController(IProductsRepository products)
        {
            this.products = products;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Description(int id)
        {
            var result = products.GetProductById(id);
            return View(result);
        }
        public ActionResult EditForm(int id)
        {
            var result = products.GetProductById(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult EditProduct(Product editProduct)
        {
            products.Edit(editProduct);
            return RedirectToAction("Index", "Admin");
        }
        public ActionResult DeleteProduct(int id)
        {
            products.DeleteItem(id);
            return RedirectToAction("Index", "Admin");
        }
        public ActionResult AddProductForm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product newProduct)
        {
            products.Add(newProduct);
            return RedirectToAction("Index", "Admin");
        }

    }
}
