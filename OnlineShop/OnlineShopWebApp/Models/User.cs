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
            Id = Guid.NewGuid();
            Login = login;
            Orders = new List<Order>();
            Contacts = new UserContact() { Name="", Surname= "", Email= "", Phone= "", Adress= "" };
            Role = new Role();
            Role.Name = "";
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
        public void UpdateUser(User newUser)
        {
            Login.Name = newUser.Login.Name;
            Login.Password = newUser.Login.Password;
            Contacts.Name = newUser.Contacts.Name;
            Contacts.Surname = newUser.Contacts.Surname;
            Contacts.Email = newUser.Contacts.Email;
            Contacts.Adress = newUser.Contacts.Adress;
            Contacts.Phone = newUser.Contacts.Phone;
            Role.Name = newUser.Role.Name;
        }
    }
}
