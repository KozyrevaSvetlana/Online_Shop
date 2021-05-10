using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IOrdersRepository
    {
        IEnumerable<Order> AllUsers { get; }

        void AddOrder(Order order);
        Order GetLastOrder(string userId);
    }
}