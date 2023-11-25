using Microsoft.AspNetCore.Identity;

namespace ModelsLibrary.ModelsDto
{
    public class User : IdentityUser
    {
        public string ContactsName { get; set; }
        public string Surname { get; set; }
        public string Adress { get; set; }
        public string Image { get; set; }
    }
}