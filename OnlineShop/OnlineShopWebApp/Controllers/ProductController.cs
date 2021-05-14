using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Models.Interfaces;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsRepository products;
        private readonly ICartsRepository cartsRepository;

        public ProductController(IProductsRepository products, ICartsRepository cartsRepository)
        {
            this.products = products;
            this.cartsRepository = cartsRepository;
        }

        // GET: ProductController
        public ActionResult Index(int id)
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
        public ActionResult EditProduct(EditProduct product)
        {
            products.Edit(product);
            return RedirectToAction("Index", "Admin");
        }
        public ActionResult DeleteProduct(int id)
        {
            products.DeleteItem(id);
            return RedirectToAction("Index", "Admin");
        }
    }
}
