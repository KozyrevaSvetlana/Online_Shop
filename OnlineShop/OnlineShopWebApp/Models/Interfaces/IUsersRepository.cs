using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public interface IUsersRepository
    {
        void AddUser(User user);
        User TryGetByUserId(string userId);
    }
}