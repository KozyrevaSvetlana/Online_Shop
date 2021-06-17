using Microsoft.AspNetCore.Identity;

namespace OnlineShop.Db.Models
{
    public class User : IdentityUser
    {
        public virtual string ContactsName { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Adress { get; set; }
    }
}