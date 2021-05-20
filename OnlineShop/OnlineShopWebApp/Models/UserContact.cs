using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class UserContact
    {
        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(44, MinimumLength = 2, ErrorMessage = "Имя должно быть не менее 2 и не более 44 символов")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Не указана фамилия")]
        [StringLength(44, MinimumLength = 2, ErrorMessage = "Фамилия должна быть не менее 2 и не более 44 символов")]
        public string Surname { get; set; }


        [Required(ErrorMessage = "Не указан адрес")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Неккоректный адрес. Он должен быть не менее 2 и не более 100 символов")]
        public string Adress { get; set; }


        [Required(ErrorMessage = "Не указан телефон")]
        [StringLength(16, MinimumLength = 3, ErrorMessage = "Телефон должен быть не менее 3 и не более 16 символов")]
        public string Phone { get; set; }


        [Required(ErrorMessage = "Не указан email")]
        [EmailAddress(ErrorMessage = "Укажите верный email")]
        public string Email { get; set; }
    }
}