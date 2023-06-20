using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Db.Models.Interfaces
{
    public interface ICartsRepository
    {
        Task<IEnumerable<Cart>> AllCarts();
        Task<Cart> TryGetByUserId(string userId);
        Task Add(Product product, string userId);
        Task<int> GetAllAmounts(string userId);
        Task ChangeAmount(Product product, int sign, string userId);
        Task ClearCart(string userId);
        Task<bool> IsInCart(Product product);
    }
}