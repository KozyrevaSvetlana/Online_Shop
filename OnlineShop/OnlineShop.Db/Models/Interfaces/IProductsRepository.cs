using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Db.Models.Interfaces
{
    public interface IProductsRepository 
    {
        Task<List<Product>> Search(string[] seachResults);
        Task EditAsync(Product product);
        Task CreateAsync(Product product);
    }
}