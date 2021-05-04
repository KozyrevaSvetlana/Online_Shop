using System.Collections.Generic;

namespace OnlineShopWebApp.Models.Interfaces
{
    public interface IComparesList
    {
        IEnumerable<Product> _comparesList { get; }
        void Add(Product product);
        void Delete(int productId);
        void Clear();
    }
}
