using OnlineShopWebApp.Models;
using OnlineShopWebApp.Models.Interfaces;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public class InMemoryUsersRepository: IUsersRepository
    {
        private List<User> users = new List<User>();
        public void AddUser(User user)
        {
            users.Add(user);
        }

        public IEnumerable<User> AllUsers
        {
            get
            {
                return users;
            }
        }
    }
}
