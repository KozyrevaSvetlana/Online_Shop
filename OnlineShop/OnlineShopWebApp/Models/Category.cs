using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public class Category
    {
        public static int Counter = 1;
        public int Id { get; }
        public string Name { get; set; }
        public List<string> Items { get; set; }
        public Category (string name, List<string> items)
        {
            Id = Counter;
            Name = name;
            Counter++;
            Items = items;
        }
    }
}
