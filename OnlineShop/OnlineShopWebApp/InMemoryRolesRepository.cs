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

        public Role GetRoleByName(string name)
        {
            return roles.FirstOrDefault(p => p.Name == name);
        }

        public void DeleteRole(string name)
        {
            roles.RemoveAll(x => x.Name == name);
        }
        public void Edit(string newName, string name)
        {
            var role = AllRoles.FirstOrDefault(p => p.Name == name);
            role.Name = newName;
        }
        public void Add(string name)
        {
            roles.Add(new Role(name));
        }
        public List<string> IsValid(string name)
        {
            var result = new List<string>();
            foreach (var role in roles)
            {
                if (role.Name == name)
                {
                    result.Add("Такое название уже существует");
                    break;
                }
            }
            for (int i = 0; i < name.Length; i++)
            {
                if(!char.IsLetterOrDigit(name[i]))
                {
                    result.Add("Yазвание должно содержать только буквы и/или цифры");
                    break;
                }
            }
            return result;
        }
    }
}
