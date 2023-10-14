using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Db.Models.Interfaces
{
    public interface IProductsRepository : IBaseRepository<Product>
    {
        Task<List<Product>> Search(string[] seachResults);
    }
}