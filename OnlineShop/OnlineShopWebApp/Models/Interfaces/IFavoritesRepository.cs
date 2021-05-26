using OnlineShopWebApp.Models;
using OnlineShopWebApp.Models.Interfaces;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IFavoritesRepository: IBaseProductList
    {
        void Add(Product product, string userId);
        void DeleteItem(int id, string userId);
    }
}