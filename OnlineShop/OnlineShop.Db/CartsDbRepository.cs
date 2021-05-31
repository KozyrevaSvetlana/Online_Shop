using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db
{
    public class CartsDbRepository : ICartsRepository
    {
        private readonly DatabaseContext databaseContext;

        public CartsDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public IEnumerable<Cart> AllCarts
        {
            get
            {
                return databaseContext.Carts;
            }
        }
        public Cart TryGetByUserId(string userId)
        {
            return databaseContext.Carts.FirstOrDefault(x => x.UserId == userId);
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
                var userCartItem = userCart.CartItems.FirstOrDefault(x => x.Product.Id == product.Id);
                if (userCartItem != null)
                {
                    userCartItem.Amount += 1;
                }
                else
                {
                    userCart.CartItems.Add(AddNewCartItem(product));
                }
            }
            databaseContext.SaveChanges();
        }
        public int GetAllAmounts(string userId)
        {
            var userCart = TryGetByUserId(userId);
            return userCart?.CartItems?.Sum(x => x.Amount) ?? 0;
        }
        private void AddNewCart(Product product, string userId)
        {
            var newCart = new Cart
            {
                UserId = userId,
                CartItems = new List<CartItem>
                    {
                        AddNewCartItem(product)
                    }
            };
            databaseContext.Carts.Add(newCart);
            databaseContext.SaveChanges();
        }

        private CartItem AddNewCartItem(Product product)
        {
            return new CartItem
            {
                Amount = 1,
                Product = product,
            };
        }

        public void ChangeAmount(Product product, int sign, string userId)
        {
            var userCart  = TryGetByUserId(userId);
            var userCartItem = userCart.CartItems.FirstOrDefault(x => x.Product.Id == product.Id);
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
            databaseContext.SaveChanges();
        }

        private void DeleteItem(CartItem cartItem, string userId)
        {
            var userCart = TryGetByUserId(userId);
            userCart.CartItems.RemoveAll(x => x.Id == cartItem.Id);
            databaseContext.SaveChanges();
        }

        public void ClearCart(string userId)
        {
            var userCart = TryGetByUserId(userId);
            userCart.CartItems.Clear();
            databaseContext.SaveChanges();
        }
    }
}
