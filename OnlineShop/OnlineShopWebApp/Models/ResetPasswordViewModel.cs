using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace OnlineShopWebApp.Models
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Не указан email")]
        [EmailAddress(ErrorMessage = "Укажите верный email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength(35, MinimumLength = 4, ErrorMessage = "Пароль должен быть минимум 4 символа, максимум 35 символов")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }
}
