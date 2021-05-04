using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsRepository products;

        public ProductController(IProductsRepository products)
        {
            this.products = products;
        }

        // GET: ProductController
        public ActionResult Index(int id)
        {
                var result = products.GetProductById(id);
                //ViewBag.CartItemsCount = CartsRepository.GetAllAmounts(Constants.UserId);
                return View(result);
        }
    }
}
