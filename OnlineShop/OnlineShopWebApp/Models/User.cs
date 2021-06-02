using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public Login Login { get; set; }
        public List<OrderViewModel> Orders { get; set; }
        public UserContactViewModel Contacts { get; set; }
        public Role Role { get; set; }
        public User(Login login)
        {
            Id = Guid.NewGuid();
            Login = login;
            Orders = new List<OrderViewModel>();
            Contacts = new UserContactViewModel() { Name="", Surname= "", Email= "", Phone= "", Adress= "" };
            Role = new Role();
            Role.Name = "";
        }
        public void AddOrder(OrderViewModel order)
        {
            Orders.Add(order);
        }
        public User() { }
        public void AddContacts(UserContactViewModel contacts)
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
        public List<string> GetEmptyContacts()
        {
            var result = new List<string>();
            if (Contacts.Name=="")
            {
                result.Add("Имя не заполнено");
            }
            if (Contacts.Surname == "")
            {
                result.Add("Фамилия не заполнена");
            }
            if (Contacts.Adress == "")
            {
                result.Add("Адрес не заполнен");
            }
            if (Contacts.Phone == "")
            {
                result.Add("Телефон не заполнен");
            }
            if (Contacts.Email == "")
            {
                result.Add("Email не заполнен");
            }
            return result;
        }
    }
}
