using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Db.Models.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<T> TryGetByUserId(string userId);
        Task Add(T item, string userId = null);
        Task Delete(Guid id, string userId = null);
        Task Edit(T item, string userId = null);
        Task Clear(string userId);
        Task<int> GetCount(string userId);
    }
}
