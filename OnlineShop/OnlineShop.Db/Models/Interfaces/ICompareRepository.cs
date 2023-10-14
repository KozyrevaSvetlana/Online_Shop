using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Db.Models.Interfaces
{
    public interface ICompareRepository : IBaseRepository<Compare>
    {
        Task<Compare> TryGetById(string compareId);
        Task Add(Product product, string compareId);
        Task Delete(Guid id, string compareId);
        Task Clear(string compareId);
    }
}