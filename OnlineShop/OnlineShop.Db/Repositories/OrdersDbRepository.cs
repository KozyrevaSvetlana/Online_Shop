using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Db.Repositories
{
    public class OrdersDbRepository : IOrdersRepository
    {
        private readonly DatabaseContext databaseContext;
        public OrdersDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task Add(Order order, Cart cart)
        {
            foreach (CartItem cartItem in cart.Items)
            {
                order.Items.Add(cartItem);
            }
            databaseContext.Orders.Add(order);
            databaseContext.Carts.Remove(cart);
            await databaseContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            var allOrders = await databaseContext.Orders
                .Where(q => q.UserId != null)
                .Include(x => x.Items)
                .ThenInclude(x => x.Product)
                .ToListAsync();
            foreach (var order in allOrders)
            {
                order.UserContacts = databaseContext.UserContacts.FirstOrDefault(x => x.OrderId == order.Id);
            }
            return allOrders;
        }
        public async Task<Order> TryGetByUserId(string userId)
        {
            return await databaseContext.Orders.FirstOrDefaultAsync(x => x.UserId == userId);
        }
        public async Task Edit(int number, int status)
        {
            var order = await databaseContext.Orders.FirstOrDefaultAsync(p => p.Number == number);
            order.InfoStatus = status;
            await databaseContext.SaveChangesAsync();
        }
        public async Task<Order> GetByNumber(int number)
        {
            var order = await databaseContext.Orders
                .Where(x => x.Number == number)
                .Include(x => x.Items)
                .ThenInclude(x => x.Product)
                .FirstOrDefaultAsync();
            order.UserContacts = await databaseContext.UserContacts.FirstOrDefaultAsync(x => x.OrderId == order.Id);
            return order;
        }
        public async Task Delete(int number)
        {
            var order = await databaseContext.Orders.FirstOrDefaultAsync(x => x.Number == number);
            var contacts = await databaseContext.UserContacts.FirstOrDefaultAsync(x => x.OrderId == order.Id);
            var cartItems = await databaseContext.CartItems.Include(x => x.Order).FirstOrDefaultAsync(x => x.Order == order);
            foreach (var cartItem in order.Items)
            {
                databaseContext.CartItems.Remove(cartItem);
            }
            databaseContext.UserContacts.Remove(contacts);
            databaseContext.Orders.Remove(order);
            await databaseContext.SaveChangesAsync();
        }
        public async Task<List<Order>> GetByUserId(string userId)
        {
            var allOrders = await databaseContext.Orders.Where(q => q.UserId == userId).Include(x => x.Items).ThenInclude(x => x.Product).ToListAsync();
            foreach (var order in allOrders)
            {
                order.UserContacts = await databaseContext.UserContacts.FirstOrDefaultAsync(x => x.OrderId == order.Id);
            }
            return allOrders;
        }
        public async Task<Order> GetLast(string UserId)
        {
            var order = await databaseContext.Orders
                .Where(q => q.UserId == UserId)
                .Include(x => x.Items)
                .ThenInclude(x => x.Product)
                .OrderByDescending(q => q.Number)
                .FirstOrDefaultAsync();
            order.UserContacts = await databaseContext.UserContacts.FirstOrDefaultAsync(x => x.OrderId == order.Id);
            return order;
        }
        public async Task<int> GetCount()
        {
            var result = await databaseContext.Orders.CountAsync();
            return result + 1;
        }
        public async Task<bool> IsInOrder(Guid id)
        {
            return await databaseContext.CartItems.FirstOrDefaultAsync(x => x.Product.Id == id) != null;
        }
        public async Task<List<Order>> GetOrders(Guid id)
        {
            var items = await databaseContext.CartItems.Where(x => x.Product.Id == id).ToListAsync();
            var result = new List<Order>();
            foreach (var item in items)
            {
                var resultItem = databaseContext.Orders.Include(x => x.Items).ThenInclude(x => x.Product).First(x => x.Items.Contains(item));
                result.Add(resultItem);
            }
            return result;
        }
    }
}
