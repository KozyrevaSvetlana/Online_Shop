using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Db.Models.Interfaces
{
    public interface IOrdersRepository
    {
        Task<IEnumerable<Order>> AllOrders();

        Task AddOrder(Order order, Cart cart);
        Task<Order> TryGetByUserId(string userId);
        Task Edit(int number, int status);
        Task<Order> GetOrderByNumber(int number);
        Task Delete(int number);
        Task<List<Order>> GetOrdersByUserId(string userId);
        Task<Order> GetLastOrder(string UserId);
        Task<int> CountOrders();
        Task<bool> IsInOrder(Guid id);
        Task<List<Order>> ProductInOrders(Guid id);
    }
}