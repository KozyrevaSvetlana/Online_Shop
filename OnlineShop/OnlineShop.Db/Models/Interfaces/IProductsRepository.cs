using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Db.Models.Interfaces
{
    public interface IProductsRepository : IBaseRepository<Product>
    {
        
        Task<Product> GetById(Guid id);
        Task Delete(Guid id);
        Task Edit(Product editProduct);
        Task<int> GetCount();
        Task Add(Product newProduct);
        Task<List<Product>> Search(string[] seachResults);
    }
}