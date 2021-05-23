using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(44, MinimumLength = 2, ErrorMessage = "Имя должно быть не менее 2 символов и не более 44 символов")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength(35, MinimumLength = 4, ErrorMessage = "Пароль должен быть минимум 4 символа, максимум 35 символов")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
