using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Db.Repositories
{
    public class ProductsDbRepository : IProductsRepository
    {
        private readonly DatabaseContext databaseContext;
        public ProductsDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task<IEnumerable<Models.Product>> GetAllAsync()
        {
            return await databaseContext.Products.Include(x => x.Images).ToListAsync();
        }

        public async Task<Models.Product> GetByIdAsync(System.Guid id)
        {
            return await databaseContext.Products.Include(x => x.Images).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task Delete(System.Guid id)
        {
            var deleteProduct = await databaseContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            databaseContext.Products.Remove(deleteProduct);
            await databaseContext.SaveChangesAsync();
        }
        public async Task Edit(Models.Product editProduct)
        {
            var product = await databaseContext.Products.FirstOrDefaultAsync(p => p.Id == editProduct.Id);
            product.Name = editProduct.Name;
            product.Cost = editProduct.Cost;
            product.Description = editProduct.Description;
            product.Images = editProduct.Images;
            await databaseContext.SaveChangesAsync();
        }
        public async Task<int> GetCount()
        {
            return await databaseContext.Products.CountAsync();
        }
        public async Task Add(Models.Product newProduct)
        {
            databaseContext.Products.Add(newProduct);
            await databaseContext.SaveChangesAsync();
        }

        public async Task<List<Models.Product>> Search(string[] seachResults)
        {
            var resultList = new List<Models.Product>();

            foreach (var word in seachResults)
            {
                resultList = await databaseContext.Products.Where(x => x.Name.ToLower().Contains(word.ToLower())).Include(x => x.Images).ToListAsync();
            }
            return resultList.Distinct().ToList();
        }
    }
}
