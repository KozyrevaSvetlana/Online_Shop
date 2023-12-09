using System.Collections.Generic;

namespace ModelsLibrary.ModelsVM
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public Login Login { get; set; }
        public List<OrderViewModel> Orders { get; set; }
        public UserContactViewModel Contacts { get; set; }
        public RoleViewModel Role { get; set; }
        public string Image { get; set; }
        public UserViewModel() { }
    }
}
