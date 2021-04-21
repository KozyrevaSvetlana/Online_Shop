namespace OnlineShopWebApp.Models
{
    public class Product
    {
        private static int counter;
        public int Id { get; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public Product(int id, string name, decimal cost, string description)
        {
            //counter++;
            Id = id;
            Name = name;
            Cost = cost;
            Description = description;
        }
        public override string ToString()
        {
            return $"{Id}\n{Name}\n{Cost}\n";
        }
        public string IdToString()
        {
            return $"{Id}\n{Name}\n{Cost}\n{Description}\n";
        }
    }
}
