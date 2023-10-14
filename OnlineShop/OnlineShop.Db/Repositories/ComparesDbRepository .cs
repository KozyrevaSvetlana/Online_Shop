using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Db.Repositories
{
    public class ComparesDbRepository : ICompareRepository
    {
        private readonly DatabaseContext databaseContext;
        public ComparesDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<IEnumerable<Compare>> GetAll()
        {
            return await databaseContext.Compares.ToListAsync();
        }

        public async Task Add(Models.Guid product, string UserId)
        {
            var userCompareList = await TryGetByUserId(UserId);
            if (userCompareList == null)
            {
                await AddNewCompare(product, UserId);
            }
            else
            {
                var userCartItem = userCompareList.Items.FirstOrDefault(x => x.Id == product.Id);
                if (userCartItem == null)
                {
                    userCompareList.Items.Add(product);
                }
            }
            await databaseContext.SaveChangesAsync();
        }

        public async Task Clear(string CompareId)
        {
            var result = TryGetByUserId(CompareId);
            databaseContext.Remove(result);
            await databaseContext.SaveChangesAsync();
        }

        public async Task Delete(System.Guid id, string CompareId)
        {
            var compare = await TryGetByUserId(CompareId);
            compare.Items.RemoveAll(x => x.Id == id);
            await databaseContext.SaveChangesAsync();
        }

        public async Task<Compare> TryGetByUserId(string CompareId)
        {
            return await databaseContext.Compares.Include(x => x.Items).FirstOrDefaultAsync(x => x.UserId == CompareId);
        }
        private async Task AddNewCompare(Models.Guid product, string userId)
        {
            var newCart = new Compare
            {
                UserId = userId,
                Items = new List<Models.Guid>(),
            };
            newCart.Items.Add(product);
            databaseContext.Compares.Add(newCart);
            await databaseContext.SaveChangesAsync();
        }
    }
}
