using Microsoft.EntityFrameworkCore;
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
        }
        public IEnumerable<Product> AllProducts
        {
            get
            {
                return databaseContext.Products.Include(x=>x.Images).ToList();
            }
        }

        public Product GetProductById(Guid id)
        {
            return databaseContext.Products.Include(x => x.Images).FirstOrDefault(p => p.Id == id);
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
                resultList = databaseContext.Products.Where(x => x.Name.ToLower().Contains(word.ToLower())).Include(x => x.Images).ToList();
            }
            return resultList.Distinct().ToList();
        }
    }
}
