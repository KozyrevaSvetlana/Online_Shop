using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class InMemoryCategoriesRepository : ICategoriesRepository
    {
        private List<Category> categories = new List<Category>()
        {
            new Category("Игрушки", new List<Subcategory>() {new Subcategory("Конструкторы"), new Subcategory("Куклы"),
                new Subcategory("Мягкие игрушки"), new Subcategory("Транспорт"), new Subcategory("Пирамидки"),
                new Subcategory("Игрушечное оружие"), new Subcategory("Мячи")}),
            new Category("Гигиена", new List<Subcategory>() { new Subcategory("Косметика"), new Subcategory("Подгузники"), new Subcategory("Бытовая химия")}),
            new Category("Одежда", new List<Subcategory>() { new Subcategory("Для девочек"), new Subcategory("Для мальчиков"), new Subcategory("Обувь"),
                new Subcategory("Белье"), new Subcategory("Акссесуары")})
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

        public void Delete(int id)
        {
            categories.RemoveAll(x => x.Id == id);
        }
        public void Edit(int id, string name)
        {
            var category = AllCategories.FirstOrDefault(p => p.Id == id);
            category.Name = name;
        }
        public void Add(Category newCategory, List<Subcategory> items)
        {
            var category = new Category(newCategory.Name, items);
            categories.Add(category);
        }
        public void AddItems(int id, List<Subcategory> items)
        {
            var category = AllCategories.FirstOrDefault(p => p.Id == id);
            foreach (var subcategory in category.Subcategory)
            {
                foreach (var item in items)
                {
                    if (subcategory != item)
                    {
                        category.Subcategory.Add(item);
                    }
                }
            }
        }
        public Subcategory GetSubcategoryById(int id, int idSubcategory)
        {
            return GetCategoryById(id).Subcategory.FirstOrDefault(x=>x.Id== idSubcategory);
        }
    }
}
