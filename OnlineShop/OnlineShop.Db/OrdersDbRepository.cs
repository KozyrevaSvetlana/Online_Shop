using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using static OnlineShop.Db.Models.InfoStatusOrder;

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
            var newCart = new Cart();
            foreach (CartItem cartItem in cart.Items)
            {
                newCart.Items.Add(cartItem);
            }
            order.Products = newCart;
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
        public void Edit(int number, Status status)
        {
            var order = databaseContext.Orders.FirstOrDefault(p => p.Number == number);
            order.InfoStatus.StatusOrder = (int)status;
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
            var result = new List<Order>();
            foreach (var order in databaseContext.Orders)
            {
                if(order.UserId== userId)
                {
                    result.Add(order);
                }
            }
            return result;
        }
        public Order GetLastOrder(string UserId)
        {
            return databaseContext.Orders.Last(x => x.UserId == UserId);
        }
    }
}
