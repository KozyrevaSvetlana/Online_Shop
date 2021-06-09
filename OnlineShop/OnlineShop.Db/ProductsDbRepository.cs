using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db
{
    public class ProductsDbRepository : IProductsRepository
    {
        private readonly DatabaseContext databaseContext;
        public ProductsDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
            CreateProducts();
        }
        private void CreateProducts()
        {
            var result = databaseContext.Products.Count();
            if (result==0)
            {
                databaseContext.Add(new Product() { Name = "Плюшевый мишка", Cost = 300, Description = "Плюшевый мишка – символ нежности, трогательной заботы, тепла. ",
                Image = "/img/Products/1.jpg" });
            databaseContext.Add(new Product() { Name = "Конструктор", Cost = 1000, Description = "Любознательным малышам придется по душе конструктор.",
                Image = "/img/Products/2.jpg" });
            databaseContext.Add(new Product(){Name = "Пирамидка стаканчики", Cost =200, Description = "Пирамидка собирается из стаканчиков разного размера.", Image = "/img/Products/3.jpg" });
            databaseContext.Add(new Product() { Name = "Водный пистолет", Cost =150, Description = "Благодаря водному пистолету можно весело играть в друзьями летом на лужайке", Image = "/img/Products/4.jpg" });
            databaseContext.Add(new Product() { Name = "Мяч детский", Cost =170, Description = "Мяч выполнен из прочного ПВХ и подходит для активных игр как дома, так и на воздухе", Image = "/img/Products/5.jpg" });
            databaseContext.SaveChanges();
            }
        }

        public IEnumerable<Product> AllProducts
        {
            get
            {
                return databaseContext.Products.ToList();
            }
        }

        public Product GetProductById(Guid id)
        {
            return databaseContext.Products.FirstOrDefault(p => p.Id==id);
        }

        public void DeleteItem(Guid id)
        {
            var deleteProduct = databaseContext.Products.FirstOrDefault(p => p.Id == id);
            databaseContext.Products.Remove(deleteProduct);
            databaseContext.SaveChanges();
        }
        public void Edit(Product editProduct)
        {
            var product = AllProducts.FirstOrDefault(p => p.Id == editProduct.Id);
            product.Name = editProduct.Name;
            product.Cost = editProduct.Cost;
            product.Description = editProduct.Description;
            databaseContext.SaveChanges();
        }
        public int GetCount()
        {
            return databaseContext.Products.Count();
        }
        public void Add(Product newProduct)
        {
            databaseContext.Products.Add(newProduct);
            databaseContext.SaveChanges();
        }

        public List<Product> SeachProduct(string[] seachResults)
        {
            var resultList = new List<Product>();

            foreach (var word in seachResults)
            {
                resultList = databaseContext.Products.Where(x => x.Name.ToLower().Contains(word.ToLower())).ToList();
            }
            return resultList.Distinct().ToList();
        }
    }
}
