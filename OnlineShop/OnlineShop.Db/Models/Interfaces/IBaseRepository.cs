using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Db.Models.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(Guid id, string userId);
        Task DeleteAsync(Guid id, string userId = null);
        Task<T> GetByIdAsync(Guid? id = null, string userId = null);
    }
}
