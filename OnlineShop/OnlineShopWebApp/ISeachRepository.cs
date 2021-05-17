using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public interface ISeachRepository
    {
        IEnumerable<Seach> seachProducts { get; }
        void Add(List<Product> products, string userId);
        void Clear(string userId);
        Seach TryGetByUserId(string userId);
    }
}