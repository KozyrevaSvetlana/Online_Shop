using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Db.Models.Interfaces
{
    public interface IOrdersRepository : IBaseRepository<Order>
    {
        Task Add(Order order, Cart cart);
        Task<Order> GetByNumber(int number);
        Task Edit(int number, int status);
        Task<List<Order>> GetByUserId(string userId);
        Task<Order> GetLast(string UserId);
        Task<bool> IsInOrder(Product id);
        Task<List<Order>> GetOrders(Product id);
    }
}