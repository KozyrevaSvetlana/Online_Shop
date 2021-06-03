using System.Collections.Generic;
using static OnlineShop.Db.Models.InfoStatusOrder;

namespace OnlineShop.Db.Models.Interfaces
{
    public interface IOrdersRepository
    {
        IEnumerable<Order> AllOrders { get; }

        void AddOrder(Order order, Cart cart);
        Order TryGetByUserId(string userId);
        void Edit(int number, Status status);
        Order GetOrderByNumber(int number);
        void Delete(int number);
        List<Order> GetOrdersByUserId(string userId);
        Order GetLastOrder(string UserId);
    }
}