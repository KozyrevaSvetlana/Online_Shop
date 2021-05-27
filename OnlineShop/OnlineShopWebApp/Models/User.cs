using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public Login Login { get; set; }
        public List<Order> Orders { get; set; }
        public UserContact Contacts { get; set; }
        public Role Role { get; set; }
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
            Contacts.Email = email;
        }
        public void AddPhone(string phone)
        {
            Contacts.Phone = phone;
        }
        public User() { }
        public void AddContacts(UserContact contacts)
        {
            Contacts = contacts;
        }
        public void AddRole(Role role)
        {
            Role = role;
        }
    }
}
