using OnlineShopWebApp.Models;
using OnlineShopWebApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class CartsRepository: ICartsRepository
    {
        private List<Cart> carts = new List<Cart>();
        public IEnumerable<Cart> AllCarts
        {
            get
            {
                return carts;
            }
        }
        public Cart TryGetByUserId(string userId)
        {
            return carts.FirstOrDefault(x => x.UserId == userId);
        }

        public void Add(Product product, string userId)
        {
            var existingCart = TryGetByUserId(userId);
            if (existingCart == null)
            {
                AddNewCart(product, userId);
            }
            else
            {
                var existingCartItem = existingCart.Items.FirstOrDefault(x => x.Product.Id == product.Id);
                if (existingCartItem != null)
                {
                    existingCartItem.Amount += 1;
                }
                else
                {
                    existingCart.Items.Add(AddNewCartItem(product));
                }
            }
        }
        public int GetAllAmounts(string userId)
        {
            var existingCart = TryGetByUserId(userId);
            return existingCart?.Items?.Sum(x => x.Amount) ?? 0;
        }
        private void AddNewCart(Product product, string userId)
        {
            var newCart = new Cart
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Items = new List<CartItem>
                    {
                        AddNewCartItem(product)
                    }
            };

            carts.Add(newCart);
        }

        private CartItem AddNewCartItem(Product product)
        {
            return new CartItem
            {
                Id = Guid.NewGuid(),
                Amount = 1,
                Product = product,
            };
        }
    }
}
