using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Db.Models.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync(string userId = null);
        Task AddAsync(Guid? id = null, string userId = null);
        Task DeleteAsync(Guid? id = null, string userId = null);
        Task<T> GetByIdAsync(Guid? id = null, string userId = null);
    }
}
