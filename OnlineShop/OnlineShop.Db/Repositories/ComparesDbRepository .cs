using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Db.Repositories
{
    public class CompareDbRepository : ICompareRepository
    {
        private readonly IdentityContext databaseContext;
        public CompareDbRepository(IdentityContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<IEnumerable<Compare>> GetAllAsync(string userId = null)
        {
            return await databaseContext.Compares.ToListAsync();
        }

        public async Task DeleteAsync(Guid? id, string userId)
        {
            var compare = await GetByIdAsync(null, userId);
            var product = compare.Items.FirstOrDefault(x => x.Id == id);
            compare.Items.Remove(product);
            await databaseContext.SaveChangesAsync();
        }

        public async Task<Compare> GetByIdAsync(Guid? id, string CompareId)
        {
            return await databaseContext.Compares.Include(x => x.Items).FirstOrDefaultAsync(x => x.UserId == CompareId);
        }
        private async Task AddNewCompare(Product product, string userId)
        {
            var newCart = new Compare
            {
                UserId = userId,
                Items = new List<Product>(),
            };
            newCart.Items.Add(product);
            databaseContext.Compares.Add(newCart);
            await databaseContext.SaveChangesAsync();
        }

        public async Task AddAsync(Guid? id, string userId = null)
        {
            var compare = await GetByIdAsync(null, userId);
            var product = await databaseContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (compare == null)
            {
                await AddNewCompare(product, userId);
            }
            else
            {
                var item = compare.Items.FirstOrDefault(x => x.Id == product.Id);
                if (item == null)
                {
                    compare.Items.Add(product);
                }
            }
            await databaseContext.SaveChangesAsync();
        }

        public async Task ClearAsync(string userName)
        {
            var compare = await GetByIdAsync(null, userName);
            databaseContext.Remove(compare);
            await databaseContext.SaveChangesAsync();
        }
    }
}
