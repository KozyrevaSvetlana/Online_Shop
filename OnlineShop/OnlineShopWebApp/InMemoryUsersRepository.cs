using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class InMemorUsersRepository : IUsersRepository
    {
        private List<UserViewModel> users = new List<UserViewModel>() { new UserViewModel(new Login() { Name = "Света", Password = "1234", RememberMe = false }) };
        public IEnumerable<UserViewModel> AllUsers
        {
            get
            {
                return users;
            }
        }
        public UserViewModel GetUserByName(string name)
        {
            return users.FirstOrDefault(x => x.Login.Name == name);
        }
        public UserViewModel GetUserById(string id)
        {
            return users.FirstOrDefault(x => x.Id.ToString() == id);
        }
        public UserViewModel GetUserByEmail(string email)
        {
            return users.FirstOrDefault(x => x.Contacts.Email == email);
        }
        public UserViewModel GetUserByPhone(string phone)
        {
            return users.FirstOrDefault(x => x.Contacts.Phone == phone);
        }

        public void DeleteUser(UserViewModel user)
        {
            users.RemoveAll(x => x.Login.Name == user.Login.Name);
        }
        public void EditUser(UserViewModel editUser)
        {
            var user = users.FirstOrDefault(p => p.Id == editUser.Id);
            user.Contacts.Email = editUser.Contacts.Email;
            user.Login = editUser.Login;
            user.Contacts.Phone = editUser.Contacts.Phone;
        }
        public void AddUser(UserViewModel user)
        {
            users.Add(user);
        }
        public bool IsUnique(string name)
        {
            var result = users.FirstOrDefault(x => x.Login.Name == name);
            return result == null ? true : false;
        }
        public bool Contains(string name)
        {
            var result = users.FirstOrDefault(x => x.Login.Name == name);
            return result != null ? true : false;
        }
    }
}
