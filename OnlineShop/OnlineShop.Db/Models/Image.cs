using System;

namespace OnlineShop.Db.Models
{
    public class Image
    {
        public Product Id { get; set; }
        public string Url { get; set; }
        public Product ProductId { get; set; }
        public Product Product { get; set; }
    }
}
