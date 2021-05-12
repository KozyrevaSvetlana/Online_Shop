
namespace OnlineShopWebApp.Models
{
    public class NewUser
    {
        public string Name { get; set; }
        public string FirstPassword { get; set; }
        public string CheckPassword { get; set; }
        public bool ValidPassword()
        {
            return FirstPassword == CheckPassword;
        }
    }
}
