namespace OnlineShopWebApp.Models
{
    public class OrderWithoutUser
    {
        public static int Count = 0;
        public int Number { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public string UserId { get; set; }
        public Cart Cart { get; set; }

        public void AddCart(Cart cart, string userId)
        {
            Cart = cart;
            Count++;
            Number = Count;
            UserId = userId;
        }
    }
}
