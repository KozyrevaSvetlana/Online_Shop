using System;

namespace OnlineShopWebApp.Models
{
    public class BaseList
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public BaseList()
        {
            Id = Guid.NewGuid();
        }
    }
}
