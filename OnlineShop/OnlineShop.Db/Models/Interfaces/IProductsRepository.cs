using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Db.Models.Interfaces
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> AllProducts();
        Task<Product> GetProductById(Guid id);
        Task DeleteItem(Guid id);
        Task Edit(Product editProduct);
        Task<int> GetCount();
        Task Add(Product newProduct);
        Task<List<Product>> SeachProduct(string[] seachResults);
    }
}