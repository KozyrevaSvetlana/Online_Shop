using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public interface ICategoriesRepository
    {
        IEnumerable<Category> AllCategories { get; }

        void Add(Category newCategory, List<Subcategory> items);
        public void AddItems(int id, List<Subcategory> items);
        void Delete(int id);
        void Edit(int id, string name);
        Category GetCategoryById(int id);
        public Subcategory GetSubcategoryById(int idSubcategory);
        Subcategory GetSubcategoryByName(string nameSubcategory, string nameCategory);
        public Category GetCategoryByName(string name);
        public Category GetCategoryBySubcategoryId(int idSubcategory);
    }
}