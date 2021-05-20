using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Product
    {
        private static int counter;
        public int Id { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Имя должно быть не менее 2 символов и не более 100 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Цена не указана")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Не указано описание")]
        [StringLength(300, MinimumLength = 2, ErrorMessage = "Описание должно быть не менее 2 символов и не более 300 символов")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Не указана подкатегория товара")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Описание должно быть не менее 2 символов и не более 50 символов")]
      
        public string CategoryItem { get; set; }
       
        public string Category { get; set; }

        [Required(ErrorMessage = "Не указан путь изображению товара")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Путь к изображению товара должен быть не менее 2 символов и не более 100 символов")]
        public string Image { get; set; }

        public Product()
        {
        }
        public Product(string name, decimal cost, string description, string image, string categoryItem, string category)
        {
            counter++;
            Id = counter;
            Name = name;
            Cost = cost;
            Description = description;
            Image = image;
            CategoryItem = categoryItem;
            Category = category;
        }

        public List<string> IsValid()
        {
            var errors = new List<string>();
            if (Name == CategoryItem)
            {
                errors.Add("Имя и Подкатегория не должны совпадать");
            }
            if (Name == Category)
            {
                errors.Add("Имя и Категория не должны совпадать");
            }
            if (CategoryItem == Category)
            {
                errors.Add("Категория и Подкатегория не должны совпадать");
            }
            if (!IsLetterOrDigit(Name))
            {
                errors.Add("Имя должно состоять только из букв и/или цифр");
            }
            if (!IsLetterOrDigit(Category))
            {
                errors.Add("Категория должна состоять только из букв");
            }
            if (!IsLetterOrDigit(CategoryItem))
            {
                errors.Add("Подкатегория должна состоять только из букв");
            }
            return errors;
        }
        private bool IsLetterOrDigit(string name)
        {
            for (int i = 0; i < name.Length; i++)
            {
                if (!char.IsLetterOrDigit(name[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
