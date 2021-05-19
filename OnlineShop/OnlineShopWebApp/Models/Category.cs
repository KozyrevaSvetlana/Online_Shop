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
            AddItem(items);
        }
        private void AddItem(List<string> items)
        {
            foreach (var item in items)
            {
                Items.Add(item);
            }
        }
    }
}
