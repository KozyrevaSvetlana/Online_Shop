using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface ICompareRepository
    {
        IEnumerable<Compare> AllCompare { get; }

        void Clear(string userId);
        Compare TryGetByUserId(string userId);
        public void Add(Product product, string userId);
        public void DeleteItem(Product product, string userId);
    }
}