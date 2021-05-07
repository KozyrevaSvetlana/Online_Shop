using OnlineShopWebApp.Models;
using OnlineShopWebApp.Models.Interfaces;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public class InMemoryUsersRepository: IUsersRepository
    {
        private List<User> users = new List<User>();
        public void AddUser(string name, string surname, string adress, string phone, string email, string comment, Cart cart)
        {
            var user = new User(name, surname, adress, phone, email);
            user.AddOrder(comment, cart);
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
