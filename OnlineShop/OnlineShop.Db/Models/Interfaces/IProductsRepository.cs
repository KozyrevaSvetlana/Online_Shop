using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Db.Models.Interfaces
{
    public interface IProductsRepository : IBaseRepository<Product>
    {
        Task<List<Product>> Search(string[] seachResults);
        Task EditAsync(Guid id, string userId = null);
        Task<int> GetCountAsync(string userId);
        Task CreateAsync(string userId);
        Task DeleteAsync(Guid id, string userId = null);
    }
}