using OnlineShopWebApp.Models.Interfaces;
using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public interface ISeachRepository : IBaseProductList
    {
        public void Add(List<Product> product, string userId);
    }
}