using System.Collections.Generic;

namespace OnlineShopWebApp.Models.Interfaces
{
    public interface ICartsRepository
    {
        IEnumerable<Cart> AllCarts { get; }
        Cart TryGetByUserId(string userId);
        void Add(ProductViewModel product, string userId);
        int GetAllAmounts(string userId);
        void ChangeAmount(ProductViewModel product, int sign, string userId);
        public void ClearCart(string userId);
    }
}
