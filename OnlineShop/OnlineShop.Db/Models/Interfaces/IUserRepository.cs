using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Db.Models.Interfaces
{
    public interface IUserRepository<T>
    {
        Task ClearAsync(string userId);
        Task<T> GetByUserIdAsync(string userId);
        Task<int> GetCountAsync(string userId);
    }
}
