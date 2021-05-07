using System;

namespace OnlineShopWebApp.Models
{
    public class Order
    {
        private static int number = 1;
        public int Id { get; set; }

        public string Сomment { get; set; }

        public Cart Cart { get; set; }
        public Order (string comment, Cart cart)
        {
            Сomment = comment;
            Cart = cart;
            Id = number;
            number++;
        }

        public int GetOrderNumber()
        {
            return Id;
        }
    }
}
