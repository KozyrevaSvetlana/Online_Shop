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
        public Subcategory GetSubcategoryByName(string nameSubcategory, string nameCategory)
        {
            var result = categories.FirstOrDefault(x => x != null).Subcategory.FirstOrDefault(x => x.Name == nameSubcategory);
            if (result ==null)
            {
                var categoryResult = categories.FirstOrDefault(x => x.Name == nameCategory);
                if (categoryResult == null)
                {
                    categories.Add(new Category(nameCategory, new List<Subcategory>() { new Subcategory(nameSubcategory) }));
                }
                else
                {
                    categoryResult.Subcategory.Add(new Subcategory(nameSubcategory));
                }
            }
            return categories.FirstOrDefault(x => x != null).Subcategory.FirstOrDefault(x => x.Name == nameSubcategory);
        }
        public Category GetCategoryByName(string name)
        {
            var result = categories.FirstOrDefault(x => x.Name== name);
            if (result != null)
            {
                return result;
            }
            else
            {
                categories.Add(new Category(name, new List<Subcategory>()));
                return categories.FirstOrDefault(x => x.Name == name);
            }
        }
        public List<string> GetCategoryItemsByName(string name)
        {
            return AllCategories.FirstOrDefault(p => p.Name == name).Items;
        }
    }
}
