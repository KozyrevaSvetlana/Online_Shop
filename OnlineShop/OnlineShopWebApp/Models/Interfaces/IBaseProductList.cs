using System.Collections.Generic;

namespace OnlineShopWebApp.Models.Interfaces
{
    public interface IBaseProductList
    {
        IEnumerable<BaseProductList> AllProducts { get; }

        void Clear(string userId);
        BaseProductList TryGetByUserId(string userId);
    }
}
