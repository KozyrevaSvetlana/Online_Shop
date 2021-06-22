using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db
{
    public class NoGegisterUsersDbRepository : INoGegisterUsersRepository
    {
        private readonly DatabaseContext databaseContext;

        public NoGegisterUsersDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public IEnumerable<NoGegisterUser> AllUsers
        {
            get
            {
                return databaseContext.NoGegisterUsers;
            }
        }

        public void AddUser(NoGegisterUser user)
        {
            databaseContext.NoGegisterUsers.Add(user);
            databaseContext.SaveChanges();
        }

        public void Delete(string id)
        {
            var user = databaseContext.NoGegisterUsers.FirstOrDefault(x => x.Id == id);
            databaseContext.NoGegisterUsers.Remove(user);
            databaseContext.SaveChanges();
        }

        public NoGegisterUser GetUserById(string id)
        {
            return databaseContext.NoGegisterUsers.Include(x => x.Cart).ThenInclude(x=>x.Items).ThenInclude(x => x.Product).FirstOrDefault(x => x.Id == id);
        }
    }
}
