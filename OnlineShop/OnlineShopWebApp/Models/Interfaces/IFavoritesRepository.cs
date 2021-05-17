using OnlineShopWebApp.Models;
using OnlineShopWebApp.Models.Interfaces;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IFavoritesRepository: IBaseProductList
    {
        public void Add(Product product, string userId);
        public void DeleteItem(int id, string userId);
    }
}