using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Models.Interfaces
{
    public interface ICartsRepository
    {
        IEnumerable<Cart> AllCarts { get; }
        Cart TryGetByUserId(string userId);
        void Add(Product product, string userId);
        int GetAllAmounts(string userId);
        void ChangeAmount(Product product, int sign, string userId);
        public void ClearCart(string userId);
    }
}
