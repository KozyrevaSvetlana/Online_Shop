using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class InMemoryFavoritesRepository : IFavoritesRepository
    {
        private List<Favorites> favoritesList = new List<Favorites>();
        public IEnumerable<Favorites> AllFavoritesList
        {
            get
            {
                return favoritesList;
            }
        }
        public Favorites TryGetByUserId(string userId)
        {
            return favoritesList.FirstOrDefault(x => x.UserId == userId);
        }

        public void DeleteItem(Product product, string userId)
        {
            var userFavoritesList = TryGetByUserId(userId);
            userFavoritesList.Items.RemoveAll(x => x.Id == product.Id);
        }

        public void Clear(string userId)
        {
            var userFavoritesList = TryGetByUserId(userId);
            userFavoritesList.Items.Clear();
        }
        public void Add(Product product, string userId)
        {
            var userFavoritesList = TryGetByUserId(userId);
            if (userFavoritesList == null)
            {
                AddNewFavorites(product, userId);
            }
            else
            {
                var userFavoritesItem = userFavoritesList.Items.FirstOrDefault(x => x.Id == product.Id);
                if (userFavoritesItem == null)
                {
                    userFavoritesList.Items.Add(product);
                }
            }
        }
        private void AddNewFavorites(Product product, string userId)
        {
            var newFavorites = new Favorites
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Items = new List<Product>()
            };
            newFavorites.Items.Add(product);
            favoritesList.Add(newFavorites);
        }
    }
}
