using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Db.Models.Interfaces
{
    public interface IFavoritesRepository
    {
        Task<IEnumerable<Favorites>> GetAll();
        Task<Favorites> TryGetByUserId(string userId);
        Task Add(Product product, string userId);
        Task Delete(Guid id, string userId);
        Task Clear(string userId);
    }
}