using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Db.Repositories
{
    public class CartsDbRepository : ICartsRepository
    {
        private readonly IdentityContext databaseContext;

        public CartsDbRepository(IdentityContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<IEnumerable<Cart>> GetAllAsync(string userId = null)
        {
            return await databaseContext.Carts.ToListAsync();
        }

        public async Task<Cart> GetByUserIdAsync(string userId)
        {
            var cart =  await databaseContext.Carts
                .Include(x => x.Items)
                .ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(x => x.UserId == userId);
            return cart;
        }

        public async Task<int> GetCountAsync(string userId)
        {
            var userCart = await GetByUserIdAsync(userId);
            return userCart?.Items?.Sum(x => x.Amount) ?? 0;
        }

        public async Task ChangeAmountAsync(Product product, int sign, string userId)
        {
            var cart = await GetByUserIdAsync(userId);
            var item = cart.Items.FirstOrDefault(x => x.Product.Id == product.Id);
            switch (sign)
            {
                case 1:
                    item.Amount++;
                    break;
                case -1:
                    if (item.Amount > 1)
                    {
                        item.Amount--;
                    }
                    else
                    {
                        cart.Items.Remove(item);
                    }
                    break;
            }
            await databaseContext.SaveChangesAsync();
        }

        public async Task ClearAsync(string userId)
        {
            var userCart = await GetByUserIdAsync(userId);
            userCart.Items.Select(x => databaseContext.Remove(x));
            databaseContext.Carts.Remove(userCart);
            await databaseContext.SaveChangesAsync();
        }

        public async Task<bool> IsInCartAsync(Product product)
        {
            return await databaseContext.Carts.Include(x => x.Items).ThenInclude(x => x.Product.Id == product.Id).AnyAsync();
        }

        public async Task<Cart> GetByIdAsync(Guid? id)
        {
            return await databaseContext.Carts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Guid? id, string userId = null)
        {
            var cart = await GetByUserIdAsync(userId);
            var product = await databaseContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (cart == null)
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
                AddItem(cart, product);
            }
            await databaseContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid? id, string userId = null)
        {
            await ClearAsync(userId);
        }


        private static void AddItem(Cart cart, Product product)
        {
            var item = cart.Items.FirstOrDefault(x => x.Product.Id == product.Id);
            if (item != null)
            {
                item.Amount += 1;
            }
            else
            {
                cart.Items.Add(new CartItem
                {
                    Amount = 1,
                    Product = product,
                    Cart = cart
                });
            }
        }

        public async Task AddAsync(Cart cart)
        {
            await databaseContext.Carts.AddAsync(cart);
        }

        public async Task<Cart> GetByIdAsync(Guid? id = null, string userId = null)
        {
            return await databaseContext.Carts
                .Include(x=> x.Items)
                .ThenInclude(x=> x.Product)
                .FirstOrDefaultAsync(x=> x.Id == id || (!string.IsNullOrEmpty(userId) && x.UserId == userId));
        }
    }
}
