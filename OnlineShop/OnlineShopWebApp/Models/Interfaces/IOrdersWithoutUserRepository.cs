using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IOrdersWithoutUserRepository
    {
        IEnumerable<OrderWithoutUser> AllUsers { get; }

        void AddOrder(OrderWithoutUser order, Cart cart, string userId);
        OrderWithoutUser GetLastOrder(string userId);
    }
}