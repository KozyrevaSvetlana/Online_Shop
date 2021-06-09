using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db
{
    public class OrdersDbRepository : IOrdersRepository
    {
        private readonly DatabaseContext databaseContext;
        public OrdersDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public void AddOrder(Order order, Cart cart)
        {
            foreach (CartItem cartItem in cart.Items)
            {
                order.Items.Add(cartItem);
            }
            databaseContext.Orders.Add(order);
            databaseContext.Carts.Remove(cart);
            databaseContext.SaveChanges();
        }

        public IEnumerable<Order> AllOrders
        {
            get
            {
                return databaseContext.Orders;
            }
        }
        public Order TryGetByUserId(string userId)
        {
            return databaseContext.Orders.FirstOrDefault(x => x.UserId == userId);
        }
        public void Edit(int number, int status)
        {
            var order = databaseContext.Orders.FirstOrDefault(p => p.Number == number);
            order.InfoStatus = status;
            databaseContext.SaveChanges();
        }
        public Order GetOrderByNumber(int number)
        {
            return databaseContext.Orders.Where(x => x.Number == number).FirstOrDefault();
        }
        public void Delete(int number)
        {
            databaseContext.Orders.Remove(databaseContext.Orders.FirstOrDefault(x => x.Number == number));
            databaseContext.SaveChanges();
        }
        public List<Order> GetOrdersByUserId(string userId)
        {
            var allOrders = databaseContext.Orders.Where(q => q.UserId == userId).Include(x => x.Items).ThenInclude(x => x.Product).ToList();
            foreach (var order in allOrders)
            {
                order.UserContacts = databaseContext.UserContacts.FirstOrDefault(x => x.OrderId == order.Id);
            }
            return allOrders;
        }
        public Order GetLastOrder(string UserId)
        {
            var order = databaseContext.Orders.Where(q => q.UserId == UserId).Include(x => x.Items).ThenInclude(x => x.Product).OrderByDescending(q => q.Number).FirstOrDefault();
            order.UserContacts = databaseContext.UserContacts.FirstOrDefault(x => x.OrderId == order.Id);
            return order;
        }
        public int CountOrders()
        {
            var result = databaseContext.Orders.Count();
            return result + 1;
        }
    }
}
