using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Db.Models.Interfaces
{
    public interface ICartsRepository : IBaseRepository<Cart>
    {
        Task ChangeAmount(Guid product, int sign, string userId);
        Task<bool> IsInCart(Guid product);
    }
}