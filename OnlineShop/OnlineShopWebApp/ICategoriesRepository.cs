using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public interface ICategoriesRepository
    {
        IEnumerable<Category> AllCategories { get; }

        void Add(Category newCategory, List<string> items);
        void AddItems(int id, List<string> items);
        void Delete(int id);
        void Edit(int id, string name);
        Category GetCategoryById(int id);
        public string GetCategoryItem(string item);
    }
}