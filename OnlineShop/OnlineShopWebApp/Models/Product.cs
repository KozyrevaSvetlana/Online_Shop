using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Models
{
    public class Product
    {
        private static int counter;
        public int Id { get; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public Product(string name, decimal cost, string description)
        {
            counter++;
            Id = counter;
            Name = name;
            Cost = cost;
            Description = description;
        }
    }
}
