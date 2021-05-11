using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class Order
    {
        public static int Count = 0;
        public int Number { get; set; }
        public string Comment { get; set; }
        public string UserId { get; set; }
        public List<CartItem> Products { get; set; }
        public UserContact User { get; set; }

        public void AddContacts(string userId, UserContact user)
        {
            Count++;
            Number = Count;
            UserId = userId;
            User = user;
        }
        public void AddCart(Cart cart)
        {
            Products = cart.Items;
        }
        public decimal Cost
        {
            get
            {
                return Products.Sum(x => x.Cost * x.Amount);
            }
        }
    }
}
