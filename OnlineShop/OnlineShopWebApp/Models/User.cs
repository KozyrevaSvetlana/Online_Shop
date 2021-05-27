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
            Contacts = new UserContact() { Name="Неизвестно", Surname= "Неизвестно", Email= "Неизвестно", Phone= "Неизвестно", Adress= "Неизвестно" };
        }
        public void AddOrder(Order order)
        {
            Orders.Add(order);
        }
        public User() { }
        public void AddContacts(UserContact contacts)
        {
            Contacts.Name = contacts.Name;
            Contacts.Surname = contacts.Surname;
            Contacts.Email = contacts.Email;
            Contacts.Phone = contacts.Phone;
            Contacts.Adress = contacts.Adress;
        }
        public void AddRole(Role role)
        {
            Role = role;
        }
    }
}
