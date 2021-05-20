using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class InMemoryCategoriesRepository : ICategoriesRepository
    {
        private List<Category> categories = new List<Category>()
        {
            new Category("Игрушки", new List<string>() {"Конструкторы", "Куклы", "Мягкие игрушки","Транспорт", "Пирамидки", "Игрушечное оружие", "Мячи"}),
            new Category("Гигиена", new List<string>() {"Косметика", "Подгузники","Бытовая химия" }),
            new Category("Одежда", new List<string>() {"Для девочек","Для мальчиков","Обувь","Белье","Акссесуары" })
        };
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return categories;
            }
        }
        public Category GetCategoryById(int id)
        {
            return AllCategories.FirstOrDefault(p => p.Id == id);
        }
        public Category GetCategoryByName(string name)
        {
            return AllCategories.FirstOrDefault(p => p.Name == name);
        }
        public string GetCategoryItem(string name)
        {
            string result=null;
            foreach (Category category in categories)
            {
                var items = category.Items;
                var nameOfCategory = category.Name;
                foreach (var item in items)
                {
                    if (name== item)
                    {
                        result = nameOfCategory;
                    }
                }
            }
            return result;
        }
        public void Delete(int id)
        {
            categories.RemoveAll(x => x.Id == id);
        }
        public void Edit(int id, string name)
        {
            var category = AllCategories.FirstOrDefault(p => p.Id == id);
            category.Name = name;
        }
        public void Add(Category newCategory, List<string> items)
        {
            var category = new Category(newCategory.Name, items);
            categories.Add(category);
        }
        public void AddItems(int id, List<string> items)
        {
            var category = AllCategories.FirstOrDefault(p => p.Id == id);
            foreach (var categoryItem in category.Items)
            {
                foreach (var item in items)
                {
                    if (categoryItem != item)
                    {
                        category.Items.Add(item);
                    }
                }
            }
        }
        public List<string> GetCategoryItemsByName(string name)
        {
            return AllCategories.FirstOrDefault(p => p.Name == name).Items;
        }
    }
}
