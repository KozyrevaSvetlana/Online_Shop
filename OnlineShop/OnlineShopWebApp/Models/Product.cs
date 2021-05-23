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
        public Category Category { get; set; }
        public Subcategory Subcategory { get; set; }

        [Required(ErrorMessage = "Не указан путь изображению товара")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Путь к изображению товара должен быть не менее 2 символов и не более 100 символов")]
        public string Image { get; set; }

        public Product()
        {
        }
        public Product(string name, decimal cost, string description, string image)
        {
            counter++;
            Id = counter;
            Name = name;
            Cost = cost;
            Description = description;
            Image = image;
        }
        public void AddCategorySubcategory(Category category, Subcategory subcategory)
        {
            Category = category;
            Subcategory = subcategory;
        }

        public List<string> IsValid()
        {
            var errors = new List<string>();
            if (!IsLetterOrDigit(Name))
            {
                errors.Add("Имя должно состоять только из букв и/или цифр");
            }
            if (!IsLetterOrDigit(Description))
            {
                errors.Add("Описание должно состоять только из букв и/или цифр");
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
