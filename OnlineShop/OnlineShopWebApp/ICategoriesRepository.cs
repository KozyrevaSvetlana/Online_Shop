using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public interface ICategoriesRepository
    {
        IEnumerable<Category> AllCategories { get; }
        Category GetCategoryById(int id);
        void Delete(int id);
        void Edit(int id, string name);
        void Add(Category newCategory, List<Subcategory> items);
        void AddItems(int id, List<Subcategory> items);
        public Subcategory GetSubcategoryById(int id, int idSubcategory);




    }
}