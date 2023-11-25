using Microsoft.AspNet.Identity.EntityFramework;

namespace Models.ModelsDto
{
    public class User : IdentityUser
    {
        public string ContactsName { get; set; }
        public string Surname { get; set; }
        public string Adress { get; set; }
        public string Image { get; set; }
    }
}