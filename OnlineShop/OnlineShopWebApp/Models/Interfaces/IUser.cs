using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Models.Interfaces
{
    public interface IUser
    {
        public void CreateNewUser(string name, string surname, string adress, string phone, string email);
        public void AddOrder(Order order);
    }
}
