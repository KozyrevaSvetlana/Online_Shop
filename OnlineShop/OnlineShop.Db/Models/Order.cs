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
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public UserContact User { get; set; }
        public List<Product> Items { get; set; }
    public InfoStatusOrder InfoStatus { get; set; }
        public Order()
        {
            Cart = new Cart();
            User = new UserContact();
        }
    }
}
