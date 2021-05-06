using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Models
{
    public class User
    {
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
            Email = email;
            Count++;
        }
        public void AddOrder(Order order)
        {
            Orders.Add(order);
        }
    }
}
