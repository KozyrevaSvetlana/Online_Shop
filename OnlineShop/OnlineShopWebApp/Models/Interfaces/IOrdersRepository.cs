using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IOrdersRepository
    {
        IEnumerable<Order> AllOrders { get; }

        public void AddOrder(Order order, Cart cart);
        public Order GetLastOrder(string userId);
        public Order TryGetByUserId(string userId);
        public void Edit(int number, string status);
    }
}