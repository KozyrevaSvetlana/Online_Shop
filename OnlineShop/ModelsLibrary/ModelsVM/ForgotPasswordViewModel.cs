using System.ComponentModel.DataAnnotations;

namespace ModelsLibrary.ModelsVM
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Не указан email")]
        [EmailAddress(ErrorMessage = "Укажите верный email")]
        public string Email { get; set; }
    }
}
