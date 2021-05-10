using OnlineShopWebApp.Models;
using OnlineShopWebApp.Models.Interfaces;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public class InMemoryOrdersRepository : IOrdersWithoutUserRepository
    {
        private List<OrderWithoutUser> orders = new List<OrderWithoutUser>();
        public void AddOrder(OrderWithoutUser order, Cart cart)
        {
            order.AddCart(cart);
            orders.Add(order);
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
