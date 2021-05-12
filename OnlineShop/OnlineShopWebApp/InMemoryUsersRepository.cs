using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class InMemoryUsersRepository : IUsersRepository
    {
        private List<User> users = new List<User>();
        public void AddUser(User user)
        {
            users.Add(user);
        }
        public User TryGetByUserId(string userId)
        {
            return users.FirstOrDefault(x => x.UserId == userId);
        }
        private void AddOrder(User user, Order order)
        {
            if (user.Orders == null)
            {
                var newListOrders = new List<Order>();
                newListOrders.Add(order);
            }
            else
            {
                user.Orders.Add(order);
            }
        }
    }
}
