using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public class InMemoryOrdersRepository : IOrdersRepository
    {
        private List<Order> orders = new List<Order>();
        public void AddOrder(Order order)
        {
            orders.Add(order);
        }

        public Order GetLastOrder(string userId)
        {
            return orders.FindLast(x => x.UserId == userId);
        }

        public IEnumerable<Order> AllUsers
        {
            get
            {
                return orders;
            }
        }
    }
}
