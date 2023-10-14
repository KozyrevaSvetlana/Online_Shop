using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Db.Repositories
{
    public class FavoritesDbRepository : IFavoritesRepository
    {
        private readonly DatabaseContext databaseContext;
        public FavoritesDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<IEnumerable<Favorites>> GetAllAsync()
        {
            return await databaseContext.Favorites.ToListAsync();
        }

        public async Task AddAsync(Models.Product product, string UserId)
        {
            var userFavoritesList = await GetByUserIdAsync(UserId);
            if (userFavoritesList == null)
            {
                await AddNewFavorite(product, UserId);
            }
            else
            {
                var userCartItem = userFavoritesList.Items.FirstOrDefault(x => x.Id == product.Id);
                if (userCartItem == null)
                {
                    userFavoritesList.Items.Add(product);
                }
            }
            await databaseContext.SaveChangesAsync();
        }

        public async Task ClearAsync(string UserId)
        {
            var result = await GetByUserIdAsync(UserId);
            databaseContext.Remove(result);
            await databaseContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(System.Guid id, string UserId)
        {
            var favorite = await GetByUserIdAsync(UserId);
            favorite.Items.RemoveAll(x => x.Id == id);
            await databaseContext.SaveChangesAsync();
        }

        public async Task<Favorites> GetByUserIdAsync(string UserId)
        {
            return await databaseContext.Favorites.Include(x => x.Items).FirstOrDefaultAsync(x => x.UserId == UserId);
        }
        private async Task AddNewFavorite(Models.Product product, string userId)
        {
            var newCart = new Favorites
            {
                UserId = userId,
                Items = new List<Models.Product>(),
            };
            newCart.Items.Add(product);
            databaseContext.Favorites.Add(newCart);
            await databaseContext.SaveChangesAsync();
        }
    }
}
