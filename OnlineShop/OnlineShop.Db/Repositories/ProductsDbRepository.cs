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
        private readonly IdentityContext databaseContext;
        public ProductsDbRepository(IdentityContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task<IEnumerable<Product>> GetAllAsync(string userId = null)
        {
            return await databaseContext.Products.Include(x => x.Images).ToListAsync();
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await databaseContext.Products.Include(x => x.Images).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task DeleteAsync(Guid? id = null, string userId = null)
        {
            var product = await GetByIdAsync(id);
            databaseContext.Products.Remove(product);
            await databaseContext.SaveChangesAsync();
        }
        public async Task AddAsync(Guid? id = null, string userId = null)
        {
            var product = await databaseContext.Products.FirstOrDefaultAsync(x=> x.Id == id);
            databaseContext.Products.Add(product);
            await databaseContext.SaveChangesAsync();
        }

        public async Task<List<Product>> Search(string[] seachResults)
        {
            var resultList = new List<Product>();

            foreach (var word in seachResults)
            {
                resultList = await databaseContext.Products.Where(x => x.Name.ToLower().Contains(word.ToLower())).Include(x => x.Images).ToListAsync();
            }
            return resultList.Distinct().ToList();
        }

        public async Task EditAsync(Product editProduct)
        {
            var product = await GetByIdAsync(editProduct.Id);
            product.Name = editProduct.Name;
            product.Cost = editProduct.Cost;
            product.Description = editProduct.Description;
            product.Images = editProduct.Images;
            await databaseContext.SaveChangesAsync();
        }

        public async Task<int> GetCountAsync(string userId)
        {
            return await databaseContext.Products.CountAsync();
        }

        public async Task CreateAsync(Product product)
        {
            await AddAsync(product.Id);
        }

        public async Task<Product> GetByIdAsync(Guid? id = null, string userId = null)
        {
            return await databaseContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
