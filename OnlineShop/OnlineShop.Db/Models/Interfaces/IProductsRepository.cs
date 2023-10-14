using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Db.Models.Interfaces
{
    public interface IProductsRepository : IBaseRepository<Guid>
    {
        Task<List<Guid>> Search(string[] seachResults);
    }
}