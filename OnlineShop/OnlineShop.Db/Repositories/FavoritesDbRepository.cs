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

        public async Task<IEnumerable<Favorites>> AllFavorites()
        {
            return await databaseContext.Favorites.ToListAsync();
        }

        public async Task Add(Product product, string UserId)
        {
            var userFavoritesList = await TryGetByUserId(UserId);
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

        public async Task Clear(string UserId)
        {
            var result = await TryGetByUserId(UserId);
            databaseContext.Remove(result);
            await databaseContext.SaveChangesAsync();
        }

        public async Task DeleteItem(Guid id, string UserId)
        {
            var favorite = await TryGetByUserId(UserId);
            favorite.Items.RemoveAll(x => x.Id == id);
            await databaseContext.SaveChangesAsync();
        }

        public async Task<Favorites> TryGetByUserId(string UserId)
        {
            return await databaseContext.Favorites.Include(x => x.Items).FirstOrDefaultAsync(x => x.UserId == UserId);
        }
        private async Task AddNewFavorite(Product product, string userId)
        {
            var newCart = new Favorites
            {
                UserId = userId,
                Items = new List<Product>(),
            };
            newCart.Items.Add(product);
            databaseContext.Favorites.Add(newCart);
            await databaseContext.SaveChangesAsync();
        }
    }
}
