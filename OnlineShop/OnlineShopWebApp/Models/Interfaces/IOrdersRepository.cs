using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IOrdersRepository
    {
        IEnumerable<Order> AllOrders { get; }

        void AddOrder(Order order, Cart cart);
        Order GetLastOrder(string userId);
        Order TryGetByUserId(string userId);
        void Edit(int number, string status);
        Order GetOrderByNumber(int number);
        void Delete(int number);
    }
}