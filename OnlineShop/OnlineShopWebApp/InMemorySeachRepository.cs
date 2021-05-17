using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class InMemorySeachRepository : ISeachRepository
    {
        private List<Seach> seachResultProducts = new List<Seach>();
        public IEnumerable<BaseProductList> AllProducts
        {
            get
            {
                return seachResultProducts;
            }
        }

        public BaseProductList TryGetByUserId(string userId)
        {
            return seachResultProducts.FirstOrDefault(x => x.UserId == userId);
        }
        public void Add(List<Product> products, string userId)
        {
            var userseachResultProducts = TryGetByUserId(userId);
            if (products != null)
            {
                foreach (var product in products)
                {
                    if (userseachResultProducts == null)
                    {
                        AddNewSeachResult(product, userId);
                    }
                    else
                    {
                        var userCartItem = userseachResultProducts.Items.FirstOrDefault(x => x.Id == product.Id);
                        if (userCartItem == null)
                        {
                            userseachResultProducts.Items.Add(product);
                        }
                    }
                }
            }
        }
        public void Clear(string userId)
        {
            var userseachResultProducts = TryGetByUserId(userId);
            userseachResultProducts.Items.Clear();
        }
        private void AddNewSeachResult(Product product, string userId)
        {
            var newCart = new Seach
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Items = new List<Product>()
            };
            newCart.Items.Add(product);
            seachResultProducts.Add(newCart);
        }

        public void Add(Product product, string userId)
        {
            throw new NotImplementedException();
        }

        public void DeleteItem(int id, string userId)
        {
            var userFavoritesList = TryGetByUserId(userId);
            userFavoritesList.Items.RemoveAll(x => x.Id == id);
        }
    }
}
