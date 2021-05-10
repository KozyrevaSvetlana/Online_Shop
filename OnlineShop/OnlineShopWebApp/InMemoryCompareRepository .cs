using OnlineShopWebApp.Models;
using OnlineShopWebApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class InMemoryCompareRepository : ICompareRepository
    {
        private List<Compare> compareList = new List<Compare>();
        public IEnumerable<BaseProductList> AllProducts
        {
            get
            {
                return compareList;
            }
        }

        public BaseProductList TryGetByUserId(string userId)
        {
            return compareList.FirstOrDefault(x => x.UserId == userId);
        }

        public void DeleteItem(int id, string userId)
        {
            var userCompareList = TryGetByUserId(userId);
            userCompareList.Items.RemoveAll(x => x.Id == id);
        }

        public void Clear(string userId)
        {
            var userCompareList = TryGetByUserId(userId);
            userCompareList.Items.Clear();
        }
        public void Add(Product product, string userId)
        {
            var userCompareList = TryGetByUserId(userId);
            if (userCompareList == null)
            {
                AddNewCompare(product, userId);
            }
            else
            {
                var userCartItem = userCompareList.Items.FirstOrDefault(x => x.Id == product.Id);
                if (userCartItem == null)
                {
                    userCompareList.Items.Add(product);
                }
            }
        }
        private void AddNewCompare(Product product, string userId)
        {
            var newCart = new Compare
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Items = new List<Product>()
            };
            newCart.Items.Add(product);
            compareList.Add(newCart);
        }

        BaseList IBaseProductList.TryGetByUserId(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
