using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly IOrdersRepository ordersRepository;

        public AdminController(IProductsRepository products, IOrdersRepository ordersRepository)
        {
            this.productsRepository = products;
            this.ordersRepository = ordersRepository;
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
            return View(result);
        }
        [HttpPost]
        public ActionResult EditProduct(Product editProduct)
        {
            productsRepository.Edit(editProduct);
            return RedirectToAction("Index", "Admin");
        }
        public ActionResult DeleteProduct(int id)
        {
            productsRepository.DeleteItem(id);
            return RedirectToAction("Index", "Admin");
        }
        public ActionResult AddProductForm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product newProduct)
        {
            productsRepository.Add(newProduct);
            return RedirectToAction("Index", "Admin");
        }
        public ActionResult EditOrder(int number, string status)
        {
            ordersRepository.Edit(number, status);
            return RedirectToAction("Index", "Admin");
        }
        public ActionResult OrderForm(int number)
        {
            return View(ordersRepository.GetOrderByNumber(number));
        }
    }
}
