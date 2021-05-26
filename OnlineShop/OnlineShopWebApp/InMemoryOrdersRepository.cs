using OnlineShopWebApp.Models;
using System;
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
        public void Edit(int number, string status)
        {
            var order = orders.FirstOrDefault(p => p.Number == number);
            order.InfoStatus.ChangeStatus(status);
        }
        public Order GetOrderByNumber(int number)
        {
            return orders.FindLast(x => x.Number == number);
        }
        public void Delete(int number)
        {
            orders.Remove(orders.FirstOrDefault(x => x.Number == number));
        }

        public void CreateOrders()
        {
            var order1 = new Order();
            order1.AddContacts(Constants.UserId, new UserContact()
            { Name = "Иван", Surname = "Иванов", Adress = "Москва", Email = "ivanov@mail.ru", Phone = "9261111111" },
            new InfoStatusOrder(DateTime.Now));
            orders.Add(order1);
            var order2 = new Order();
            order2.AddContacts(Constants.UserId, new UserContact()
            { Name = "Петр", Surname = "Петров", Adress = "Красногорск", Email = "petrov@mail.ru", Phone = "9261111111" },
            new InfoStatusOrder(DateTime.Now));
            orders.Add(order2);
        }
    }
}
