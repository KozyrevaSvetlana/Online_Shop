using System.Collections.Generic;

namespace ModelsLibrary.ModelsVM
{
    public class ChangeRoleViewModel
    {
        public string UserName { get; set; }
        public List<RoleViewModel> AllRoles { get; set; }
        public List<RoleViewModel> UserRoles { get; set; }
        public ChangeRoleViewModel()
        {
            UserRoles = new List<RoleViewModel>();
        }
    }
}
