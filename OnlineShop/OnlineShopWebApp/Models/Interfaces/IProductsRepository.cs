using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public interface IProductsRepository
    {
        IEnumerable<Product> AllProducts { get; }
        Product GetProductById(int id);
        public void DeleteItem(int id);
        public void Edit(EditProduct editProduct);
        public int GetCount();
    }
}