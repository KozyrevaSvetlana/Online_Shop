using Microsoft.AspNetCore.Identity;
using System;

namespace OnlineShop.Db.Models
{
    public class User : IdentityUser
    {
        public string ContactsName { get; set; }
        public string Surname { get; set; }
        public string Adress { get; set; }
    }
}