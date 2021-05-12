using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Models.Interfaces
{
    public interface IBaseProductList
    {
        IEnumerable<BaseProductList> AllProducts { get; }

        void Clear(string userId);
        BaseProductList TryGetByUserId(string userId);
        public void Add(Product product, string userId);
        public void DeleteItem(int id, string userId);
    }
}
