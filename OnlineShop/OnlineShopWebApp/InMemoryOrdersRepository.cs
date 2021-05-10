using OnlineShopWebApp.Models;
using OnlineShopWebApp.Models.Interfaces;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public class InMemoryOrdersRepository : IOrdersWithoutUserRepository
    {
        private List<OrderWithoutUser> orders = new List<OrderWithoutUser>();
        public void AddOrder(OrderWithoutUser order, Cart cart, string userId)
        {
            order.AddCart(cart, userId);
            orders.Add(order);
        }

        public OrderWithoutUser GetLastOrder(string userId)
        {
            return orders.FindLast(x => x.UserId == userId);
        }

        public IEnumerable<OrderWithoutUser> AllUsers
        {
            get
            {
                return orders;
            }
        }
    }
}
