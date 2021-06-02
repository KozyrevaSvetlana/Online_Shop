using OnlineShopWebApp.Models;
using OnlineShopWebApp.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IFavoritesRepository: IBaseProductList
    {
        void Add(ProductViewModel product, string userId);
        void DeleteItem(Guid id, string userId);
    }
}