using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ModelsLibrary.ModelsDto;

namespace OnlineShop.Db.Models.Interfaces
{
    public interface IProductsRepository : IBaseRepository<Product>
    {
        Task<List<Product>> Search(string[] seachResults);
        Task EditAsync(Product product);
        Task CreateAsync(Product product);
        Task<(List<Product>, int)> Paginate(int take, int? page);
    }
}