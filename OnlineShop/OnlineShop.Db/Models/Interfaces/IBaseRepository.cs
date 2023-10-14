using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Db.Models.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T item);
        Task DeleteAsync(T item);
        Task<T> GetByIdAsync(Guid id);
    }
}
