using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class InMemoryRolesRepository : IRolesRepository
    {
        private List<Role> roles = new List<Role>() { new Role("Администратор") };
        public IEnumerable<Role> AllRoles
        {
            get
            {
                return roles;
            }
        }

        public Role GetProductByName(string name)
        {
            return roles.FirstOrDefault(p => p.Name == name);
        }

        public void DeleteRole(string name)
        {
            roles.RemoveAll(x => x.Name == name);
        }
        public void Edit(Role editRole)
        {
            var role = AllRoles.FirstOrDefault(p => p.Name == editRole.Name);
            role.Name = editRole.Name;
        }
        public void Add(Role newRole)
        {
            roles.Add(newRole);
        }
        public bool IsValid(Role newRole)
        {
            foreach (var role in roles)
            {
                if (role.Name == newRole.Name)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
