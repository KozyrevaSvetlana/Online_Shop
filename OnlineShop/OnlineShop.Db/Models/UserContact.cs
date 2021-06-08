using System;
using System.Collections.Generic;

namespace OnlineShop.Db.Models
{
    public class UserContact
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<CartItem> Items { get; set; }
        public List<Order> Order { get; set; }
        public UserContact()
        {
            Items = new List<CartItem>();
            Order = new List<Order>();
        }
    }
}