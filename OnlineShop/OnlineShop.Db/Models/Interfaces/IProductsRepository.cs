using System;
using System.Collections.Generic;

namespace OnlineShop.Db.Models.Interfaces
{
    public interface IProductsRepository
    {
        IEnumerable<Product> AllProducts { get; }
        Product GetProductById(Guid id);
        public void DeleteItem(Guid id);
        public void Edit(Product editProduct);
        public int GetCount();
        public void Add(Product newProduct);
        public List<Product> SeachProduct(string[] seachResults);
    }
}