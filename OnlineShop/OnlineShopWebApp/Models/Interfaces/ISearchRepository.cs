using OnlineShopWebApp.Models.Interfaces;
using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public interface ISearchRepository : IBaseProductList
    {
        public void Add(List<Product> product, string userId);
    }
}