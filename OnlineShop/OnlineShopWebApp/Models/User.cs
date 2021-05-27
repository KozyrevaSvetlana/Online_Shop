using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public Login Login { get; set; }
        public List<Order> Orders { get; set; }
        public string Email { get; set; }

        public string Phone { get; set; }

        public UserContact Contacts { get; set; }
        public User(Login login)
        {
            Id = new Guid();
            Login = login;
            Orders = new List<Order>();
        }
        public void AddOrder(Order order)
        {
            Orders.Add(order);
        }
        public void AddEmail(string email)
        {
            Email = email;
        }
        public void AddPhone(string phone)
        {
            Phone = phone;
        }
        public User() { }
        public void AddContacts(UserContact contacts)
        {
            Contacts = contacts;
        }
    }
}
