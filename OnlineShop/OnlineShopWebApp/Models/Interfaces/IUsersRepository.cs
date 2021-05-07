using System.Collections.Generic;

namespace OnlineShopWebApp.Models.Interfaces
{
    public interface IUsersRepository
    {
        IEnumerable<User> AllUsers { get; }
        public void AddUser(string name, string surname, string adress, string phone, string email, string comment, Cart cart);
        public int GetLastOrder(User user);
    }
}
