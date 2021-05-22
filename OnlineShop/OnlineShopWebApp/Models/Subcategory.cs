using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public class Subcategory
    {
        public static int Counter = 1;
        public int Id { get; }
        public string Name { get; set; }
        public List<Product> Product { get; set; }
        public Subcategory(string name)
        {
            Id = Counter;
            Name = name;
            Counter++;
        }
    }
}