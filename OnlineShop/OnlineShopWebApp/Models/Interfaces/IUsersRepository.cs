﻿using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public interface IUsersRepository
    {
        IEnumerable<User> AllUsers { get; }

        void AddUser(User user);
        void DeleteUser(User user);
        void EditUser(User editUser);
        User GetUserByEmail(string email);
        User GetUserByPhone(string phone);
        bool IsUnique(string name);
        User GetUserByName(string name);
        bool Contains(string name);
        User GetUserById(string id);
    }
}