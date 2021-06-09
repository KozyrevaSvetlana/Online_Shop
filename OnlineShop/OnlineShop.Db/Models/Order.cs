using System;
using System.Collections.Generic;

namespace OnlineShop.Db.Models
{
    public class Order
    {
        private static int count = 1;
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Comment { get; set; }
        public string UserId { get; set; }
        public UserContact UserContacts { get; set; }
        public List<CartItem> Items { get; set; }
        public int InfoStatus { get; set; }
        public DateTime Data { get; set; }
        public Order()
        {
            Items = new List<CartItem>();
            Data = DateTime.Now;
            InfoStatus = 1;
            UserContacts = new UserContact();
            Number = count;
            count++;
        }
    }
}
