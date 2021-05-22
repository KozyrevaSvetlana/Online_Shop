using System;

namespace OnlineShopWebApp.Models
{
    public class Product
    {

        private static int counter;
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public Subcategory Subcategory { get; set; }
        public string Image { get; set; }
        public Product()
        {
        }
        public Product(string name, decimal cost, string description, string image)
        {
            counter++;
            Id = counter;
            Name = name;
            Cost = cost;
            Description = description;
            Image = image;
        }
        public void AddCategory(Category category)
        {
            Category = category;
        }
        public void AddSubcategory(Subcategory subcategory)
        {
            Subcategory = subcategory;
        }
    }
}
