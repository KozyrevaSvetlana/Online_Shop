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
        private readonly DatabaseContext databaseContext;
        public CompareDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<IEnumerable<Compare>> GetAllAsync()
        {
            return await databaseContext.Compares.ToListAsync();
        }

        public async Task ClearAsync(string userId)
        {
            var compare = GetByUserIdAsync(userId);
            databaseContext.Remove(compare);
            await databaseContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id, string userId)
        {
            var compare = await GetByUserIdAsync(userId);
            var product = compare.Items.FirstOrDefault(x=> x.Id == id);
            compare.Items.Remove(product);
            await databaseContext.SaveChangesAsync();
        }

        public async Task<Compare> GetByUserIdAsync(string CompareId)
        {
            return await databaseContext.Compares.Include(x => x.Items).FirstOrDefaultAsync(x => x.UserId == CompareId);
        }
        private async Task AddNewCompare(Models.Product product, string userId)
        {
            var newCart = new Compare
            {
                UserId = userId,
                Items = new List<Models.Product>(),
            };
            newCart.Items.Add(product);
            databaseContext.Compares.Add(newCart);
            await databaseContext.SaveChangesAsync();
        }

        public async Task<Compare> GetByIdAsync(Guid id)
        {
            return await databaseContext.Compares.Include(x => x.Items).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Guid id, string userId = null)
        {
            var compare = await GetByUserIdAsync(userId);
            var product = await databaseContext.Products.FirstOrDefaultAsync(x=> x.Id == id);
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
    }
}
