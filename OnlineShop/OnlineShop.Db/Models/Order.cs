using System;

namespace OnlineShop.Db.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Comment { get; set; }
        public string UserId { get; set; }
        public Cart Products { get; set; }
        public UserContact User { get; set; }
        public InfoStatusOrder InfoStatus { get; set; }
        public Order()
        {
            Products = new Cart();
            User = new UserContact();
        }
    }
}
