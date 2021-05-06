using System;

namespace OnlineShopWebApp.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string Сomment { get; set; }

        public Cart Cart { get; set; }
        public Order (string comment, Cart cart)
        {
            Сomment = comment;
            Cart = cart;
        }
    }
}
