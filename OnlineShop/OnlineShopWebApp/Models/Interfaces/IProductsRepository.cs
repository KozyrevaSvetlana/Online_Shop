using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public interface IProductsRepository
    {
        IEnumerable<Product> AllProducts { get; }
        Product GetProductById(int id);
        public void DeleteItem(int id);
        public void Edit(Product editProduct);
        public int GetCount();
        public void Add(Product newProduct);
        public List<Product> SeachProduct(string seachWord);
    }
}