using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class InMemoryOrdersRepository : IOrdersRepository
    {
        private List<Order> orders = new List<Order>();
        public void AddOrder(Order order, Cart cart)
        {
            order.Products = AddItems(cart.Items);
            orders.Add(order);
        }

        public Order GetLastOrder(string userId)
        {
            return orders.FindLast(x => x.UserId == userId);
        }

        public IEnumerable<Order> AllOrders
        {
            get
            {
                return orders;
            }
        }
        public Order TryGetByUserId(string userId)
        {
            return orders.FirstOrDefault(x => x.UserId == userId);
        }
        private List<CartItem> AddItems(List<CartItem> items)
        {
            var result = new List<CartItem>(items.Count);
            foreach (var item in items)
            {
                result.Add(item);
            }
            return result;
        }
    }
}
