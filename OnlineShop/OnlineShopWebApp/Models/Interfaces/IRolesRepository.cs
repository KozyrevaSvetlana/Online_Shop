using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public interface IRolesRepository
    {
        IEnumerable<Role> AllRoles { get; }

        void Add(string name);
        void DeleteRole(string name);
        void Edit(string newName, string name);
        Role GetRoleByName(string name);
        List<string> IsValid(string name);
    }
}