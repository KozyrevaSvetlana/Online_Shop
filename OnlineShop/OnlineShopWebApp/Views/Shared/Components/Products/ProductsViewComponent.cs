using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Views.Shared.ViewComponents.ProductsViewComponent
{
    public class ProductsViewComponent : ViewComponent
    {
        private readonly IProductsRepository productsRepository;

        public ProductsViewComponent(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public IViewComponentResult Invoke()
        {
            var products = productsRepository.AllProducts;
            return View("Products", products);
        }
    }
}
