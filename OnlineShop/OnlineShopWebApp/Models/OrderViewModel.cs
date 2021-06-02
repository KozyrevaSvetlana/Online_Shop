using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class OrderViewModel
    {
        private static int count = 0;
        public int Number { get; set; }
        public string Comment { get; set; }
        public string UserId { get; set; }
        public List<CartItemViewModel> Products { get; set; }
        public UserContactViewModel User { get; set; }
        public InfoStatusOrderViewModel InfoStatus { get; set; }

        public void AddContacts(string userId, UserContactViewModel user, InfoStatusOrderViewModel infoStatus)
        {
            count++;
            Number = count;
            UserId = userId;
            User = user;
            InfoStatus= infoStatus;
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
