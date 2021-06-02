﻿using OnlineShop.Db.Models;
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
        }
        //private List<Product> products = new List<Product>()
        //{
        //            new Product("Плюшевый мишка", 300, "Плюшевый мишка – символ нежности, трогательной заботы, тепла. " +
        //                "Многим он знаком с первых лет жизни.", "/img/Products/1.jpg"),
        //            new Product("Конструктор", 1000, "Любознательным малышам придется по душе конструктор.",
        //                "/img/Products/2.jpg"),
        //            new Product("Пирамидка стаканчики", 200, "Пирамидка собирается из стаканчиков разного размера." +
        //                "Только соблюдая четкую последовательность от большего стаканчика к меньшему у малыша получится башенка",
        //                "/img/Products/3.jpg"),
        //            new Product("Водный пистолет", 150, "Длагодаря водному пистолету можно весело играть в друзьями летом на лужайке", "/img/Products/4.jpg"),
        //            new Product("Мяч детский", 170, "Мяч выполнен из прочного ПВХ и подходит для активных игр как дома, так и на воздухе",
        //                "/img/Products/5.jpg")
        //        };



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