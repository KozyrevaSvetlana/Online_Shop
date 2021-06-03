using System;

namespace OnlineShop.Db.Models
{
    public partial class InfoStatusOrder
    {
        public int StatusOrder { get; set; }
        public DateTime Data { get; set; }
        public Order Order { get; set; }
    }
}