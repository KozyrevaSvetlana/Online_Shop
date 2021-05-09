using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Models.Interfaces
{
    public interface IBaseProductList
    {
        IEnumerable<BaseProductsList> AllProducts { get; }

        void Clear(string userId);
        BaseProductsList TryGetByUserId(string userId);
        public void Add(Product product, string userId);
        public void DeleteItem(Product product, string userId);
    }
}
