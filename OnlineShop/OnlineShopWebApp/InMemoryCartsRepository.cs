using OnlineShopWebApp.Models;
using OnlineShopWebApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class InMemoryCartsRepository : ICartsRepository
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
            var userCart = TryGetByUserId(userId);
            if (userCart == null)
            {
                AddNewCart(product, userId);
            }
            else
            {
                var userCartItem = userCart.Items.FirstOrDefault(x => x.Product.Id == product.Id);
                if (userCartItem != null)
                {
                    userCartItem.Amount += 1;
                }
                else
                {
                    userCart.Items.Add(AddNewCartItem(product));
                }
            }
        }
        public int GetAllAmounts(string userId)
        {
            var userCart = TryGetByUserId(userId);
            return userCart?.Items?.Sum(x => x.Amount) ?? 0;
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

        public void ChangeAmount(Product product, int sign, string userId)
        {
            var userCart  = TryGetByUserId(userId);
            var userCartItem = userCart.Items.FirstOrDefault(x => x.Product.Id == product.Id);
            switch(sign)
            {
                case 1:
                    userCartItem.Amount ++;
                    break;
                case -1:
                    if (userCartItem.Amount>1)
                    {
                        userCartItem.Amount--;
                    } 
                    else
                    {
                        DeleteItem(userCartItem, userId);
                    }
                    break;
            }
        }

        private void DeleteItem(CartItem cartItem, string userId)
        {
            var userCart = TryGetByUserId(userId);
            userCart.Items.RemoveAll(x => x.Id == cartItem.Id);
        }

        public void ClearCart(string userId)
        {
            var userCart = TryGetByUserId(userId);
            userCart.Items.Clear();
        }
    }
}
