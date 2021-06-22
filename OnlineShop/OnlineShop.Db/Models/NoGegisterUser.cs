using System;

namespace OnlineShop.Db.Models
{
    public class NoGegisterUser
    {
        public string Id { get; set; }
        public Cart Cart { get; set; }
        public DateTime CartLifeTime { get; set; }
    }
}
