using System;
using System.Collections.Generic;

namespace OnlineShop.Db.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Comment { get; set; }
        public string UserId { get; set; }
        public UserContact User { get; set; }
        public List<CartItem> Items { get; set; }
        public int InfoStatus { get; set; }
        public DateTime Date { get; set; }
        public Order()
        {
            User = new UserContact();
            Items = new List<CartItem>();
            Date = DateTime.Now;
            InfoStatus = 1;
        }
    }
}
