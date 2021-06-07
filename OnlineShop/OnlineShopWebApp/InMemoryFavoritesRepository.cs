using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class InMemoryFavoritesRepository : IFavoritesRepository
    {
        private List<FavoritesViewModel> favoritesList = new List<FavoritesViewModel>();
        public IEnumerable<BaseProductList> AllProducts
        {
            get
            {
                return favoritesList;
            }
        }

        public BaseProductList TryGetByUserId(string userId)
        {
            return favoritesList.FirstOrDefault(x => x.UserId == userId);
        }

        public void DeleteItem(Guid id, string userId)
        {
            var userFavoritesList = TryGetByUserId(userId);
            userFavoritesList.Items.RemoveAll(x => x.Id == id);
        }

        public void Clear(string userId)
        {
            var userFavoritesList = TryGetByUserId(userId);
            userFavoritesList.Items.Clear();
        }
        public void Add(ProductViewModel product, string userId)
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
        private void AddNewFavorites(ProductViewModel product, string userId)
        {
            var newFavorites = new FavoritesViewModel
            {
                UserId = userId,
                Items = new List<ProductViewModel>()
            };
            newFavorites.Items.Add(product);
            favoritesList.Add(newFavorites);
        }
    }
}
