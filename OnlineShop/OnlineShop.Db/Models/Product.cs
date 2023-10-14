using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Db.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public List<CartItem> CartItems { get; set; }
        public List<Order> Orders { get; set; }
        public List<Compare> Compares { get; set; }
        public List<Favorites> Favorites { get; set; }
        public List<Image> Images { get; set; }
        public Product()
        {
            CartItems = new List<CartItem>();
            Compares = new List<Compare>();
            Favorites = new List<Favorites>();
            Images = new List<Image>();
        }
    }
}
