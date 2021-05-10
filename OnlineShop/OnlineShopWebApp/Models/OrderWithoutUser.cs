namespace OnlineShopWebApp.Models
{
    public class OrderWithoutUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public Cart Cart { get; set; }

        public void AddCart(Cart cart)
        {
            Cart = cart;
        }
    }
}
