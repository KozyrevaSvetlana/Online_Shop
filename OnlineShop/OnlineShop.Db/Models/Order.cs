using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db.Models
{
    public class Order
    {
        private static int count = 0;
        public int Number { get; set; }
        public string Comment { get; set; }
        public string UserId { get; set; }
        public List<Cart> Products { get; set; }
        public UserContact User { get; set; }
        public InfoStatusOrder InfoStatus { get; set; }
    }
}
