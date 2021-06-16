
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Role
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Не указано название роли")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Имя должно быть не менее 2 символов и не более 50 символов")]
        public string Name { get; set; }
        public Role(string name)
        {
            Name = name;
        }
        public Role()
        {
        }
    }
}
