using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class InMemorUsersRepository : IUsersRepository
    {
        private List<User> users = new List<User>() { new User(new Login() { Name = "Света", Password = "123", RememberMe = false }) };
        public IEnumerable<User> AllUsers
        {
            get
            {
                return users;
            }
        }

        public User GetUserByEmail(string email)
        {
            return users.FirstOrDefault(x => x.Email == email);
        }
        public User GetUserByPhone(string phone)
        {
            return users.FirstOrDefault(x => x.Phone == phone);
        }

        public void DeleteUser(User user)
        {
            users.RemoveAll(x => x.Id == user.Id);
        }
        public void EditUser(User editUser)
        {
            var user = users.FirstOrDefault(p => p.Id == editUser.Id);
            user.Email = editUser.Email;
            user.Login = editUser.Login;
            user.Phone = editUser.Phone;
        }
        public void AddUser(User user)
        {
            users.Add(user);
        }
        public bool IsValid(string name)
        {
            var result = users.FirstOrDefault(x => x.Login.Name == name);
            return result == null ? true : false;
        }
    }
}
