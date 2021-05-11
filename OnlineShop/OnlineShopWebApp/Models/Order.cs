using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class Order
    {
        private static int count = 0;
        public int Number { get; set; }
        public string Comment { get; set; }
        public string UserId { get; set; }
        public List<CartItem> Products { get; set; }
        public UserContact User { get; set; }

        public void AddContacts(string userId, UserContact user)
        {
            count++;
            Number = count;
            UserId = userId;
            User = user;
        }

        public decimal Cost
        {
            get
            {
                return Products?.Sum(x => x.Cost) ?? 0;
            }
        }
    }
}
