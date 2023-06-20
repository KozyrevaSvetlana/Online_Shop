using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Db
{
    public class CartsDbRepository : ICartsRepository
    {
        private readonly DatabaseContext databaseContext;

        public CartsDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<IEnumerable<Cart>> AllCarts()
        {
            return await databaseContext.Carts.ToListAsync();
        }

        public async Task<Cart> TryGetByUserId(string userId)
        {
            return await databaseContext.Carts
                .Include(x => x.Items)
                .ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task Add(Product product, string userId)
        {
            var existingCart = await TryGetByUserId(userId);
            if (existingCart == null)
            {
                var newCart = new Cart
                {
                    UserId = userId
                };

                newCart.Items = new List<CartItem>
                    {
                        new CartItem
                        {
                            Amount = 1,
                            Product = product,
                            Cart = newCart
                        }
                    };
                await databaseContext.Carts.AddAsync(newCart);
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
                    existingCart.Items.Add(new CartItem
                    {
                        Amount = 1,
                        Product = product,
                        Cart = existingCart
                    });
                }
            }
            await databaseContext.SaveChangesAsync();
        }

        public async Task<int> GetAllAmounts(string userId)
        {
            var userCart = await TryGetByUserId(userId);
            return userCart?.Items?.Sum(x => x.Amount) ?? 0;
        }

        public async Task ChangeAmount(Product product, int sign, string userId)
        {
            var userCart = await TryGetByUserId(userId);
            var userCartItem = userCart.Items.FirstOrDefault(x => x.Product.Id == product.Id);
            switch (sign)
            {
                case 1:
                    userCartItem.Amount++;
                    break;
                case -1:
                    if (userCartItem.Amount > 1)
                    {
                        userCartItem.Amount--;
                    }
                    else
                    {
                        userCart.Items.Remove(userCartItem);
                    }
                    break;
            }
            await  databaseContext.SaveChangesAsync();
        }

        public async Task ClearCart(string userId)
        {
            var userCart = await TryGetByUserId(userId);
            userCart.Items.Select(x => databaseContext.Remove(x));
            databaseContext.Carts.Remove(userCart);
            await  databaseContext.SaveChangesAsync();
        }

        public async Task<bool> IsInCart(Product product)
        {
            return await databaseContext.Carts.Include(x => x.Items).ThenInclude(x => x.Product.Id == product.Id).AnyAsync();
        }
    }
}
