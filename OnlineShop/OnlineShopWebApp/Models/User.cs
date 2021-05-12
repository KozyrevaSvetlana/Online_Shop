using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public UserContact Contacts { get; set; }
        public List<Order> Orders { get; set; }
        public bool RememberMe { get; set; }
        //временное поле пока нет БД
        public string UserId { get; set; }

        public User(string name,string password, bool rememberMe)
        {
            if (rememberMe)
            {
                Name = name;
                Password = password;
            }
        }
    }
}
