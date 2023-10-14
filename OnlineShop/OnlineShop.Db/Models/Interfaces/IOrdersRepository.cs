using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Db.Models.Interfaces
{
    public interface IOrdersRepository : IBaseRepository<Order>
    {
        Task Add(Order order, Cart cart);
        Task<Order> TryGetByUserId(string userId);
        Task Edit(int number, int status);
        Task<Order> GetByNumber(int number);
        Task Delete(int number);
        Task<List<Order>> GetByUserId(string userId);
        Task<Order> GetLast(string UserId);
        Task<int> Count();
        Task<bool> IsInOrder(Guid id);
        Task<List<Order>> GetProductInOrders(Guid id);
    }
}