using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Register
    {
        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(44, MinimumLength = 2, ErrorMessage = "Имя должно быть не менее 2 символов и не более 44 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength(35, MinimumLength = 6, ErrorMessage = "Пароль должен быть минимум 6 символов, максимум 35 символов")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не указано подтверждение пароля")]
        [StringLength(35, MinimumLength = 6, ErrorMessage = "Пароль должен быть минимум 4 символов, максимум 35 символов")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string CheckPassword { get; set; }

        [Required(ErrorMessage = "Не указан email")]
        [EmailAddress(ErrorMessage = "Укажите верный email")]
        public string Email { get; set; }

        public string ReturnUrl { get; set; }
    }
}
