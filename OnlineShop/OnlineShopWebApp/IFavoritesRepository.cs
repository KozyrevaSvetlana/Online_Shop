using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IFavoritesRepository
    {
        IEnumerable<Favorites> AllFavoritesList { get; }

        void Add(Product product, string userId);
        void Clear(string userId);
        void DeleteItem(Product product, string userId);
        Favorites TryGetByUserId(string userId);
    }
}