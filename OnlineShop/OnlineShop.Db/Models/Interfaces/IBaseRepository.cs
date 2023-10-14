using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Db.Models.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<T> TryGetByUserId(string userId);
        Task Add(Guid id, string userId);
        Task Delete(Guid id, string userId);
        Task Edit(Guid item, string userId);
        Task Clear(string userId);
        Task<int> GetCount(string userId);
    }
}
