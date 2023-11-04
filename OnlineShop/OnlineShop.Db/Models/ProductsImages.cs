using System;

namespace OnlineShop.Db.Models
{
    public  class ProductsImages
    {
        public Guid Id { get; set; }
        public Guid ImageId { get; set; }
        public Image Image { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
