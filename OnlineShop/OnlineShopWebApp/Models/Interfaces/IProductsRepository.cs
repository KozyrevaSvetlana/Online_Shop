using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public interface IProductsRepository
    {
        IEnumerable<Product> AllProducts { get; }
        Product GetProductById(int id);
    }
}