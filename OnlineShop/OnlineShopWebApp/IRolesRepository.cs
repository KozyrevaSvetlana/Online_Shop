using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public interface IRolesRepository
    {
        IEnumerable<Role> AllRoles { get; }

        void Add(Role newRole);
        void DeleteRole(string name);
        void Edit(Role editRole);
        Role GetProductByName(string name);
        bool IsValid(Role newRole);
    }
}