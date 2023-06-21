using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Не указан email")]
        [EmailAddress(ErrorMessage = "Укажите верный email")]
        public string Email { get; set; }
    }
}
