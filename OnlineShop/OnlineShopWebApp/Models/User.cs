using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public class User
    {
        public static int orderNumber = 1;
        public static int Count = 0;
        public int Id { get; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Adress { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }

        private List<Order> Orders = new List<Order>();

        public User(string name, string surname, string adress, string phone, string email)
        {
            Id = Count;
            Name = name;
            Surname = surname;
            Adress = adress;
            Phone = phone;
            Email = email;
            Count++;
        }
        public void AddOrder(string comment, Cart cart)
        {
            var userOrder = new Order(comment, cart);
            Orders.Add(userOrder);
        }
        public List<Order> GetOrders(User user)
        {
            return user.Orders;
        }
    }
}
