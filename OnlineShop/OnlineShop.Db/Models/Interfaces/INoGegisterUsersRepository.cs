using System;
using System.Collections.Generic;

namespace OnlineShop.Db.Models.Interfaces
{
    public interface INoGegisterUsersRepository
    {
        IEnumerable<NoGegisterUser> AllUsers { get; }
        NoGegisterUser GetUserById(string id);
        public void Delete(string id);
        public void AddUser(NoGegisterUser user);
    }
}