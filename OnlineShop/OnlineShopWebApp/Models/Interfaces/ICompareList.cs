using System.Collections.Generic;

namespace OnlineShopWebApp.Models.Interfaces
{
    public interface ICompareList
    {
        IEnumerable<Product> AllCompareList { get; }
        void Add(Product product);
        void Delete(Product product);
        void Clear();
    }
}
