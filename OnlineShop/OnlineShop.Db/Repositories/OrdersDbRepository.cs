using Microsoft.EntityFrameworkCore;
using ModelsLibrary.ModelsDto;
using OnlineShop.Db.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Db.Repositories
{
    public class OrdersDbRepository : IOrdersRepository
    {
        private readonly IdentityContext databaseContext;
        public OrdersDbRepository(IdentityContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
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
        public async Task<Order> GetByUserIdAsync(string userId)
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
                .Include(x => x.Items)
                .ThenInclude(x => x.Product)
                .OrderByDescending(q => q.Number)
                .FirstOrDefaultAsync(q => q.UserId == UserId);
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
            return await databaseContext.Orders
                .Include(x => x.Items)
                .ThenInclude(x => x.Product)
                .SelectMany(x => x.Items)
                .AnyAsync(x => x.Product.Id == id);
        }
        public async Task<List<Order>> GetOrders(Guid id)
        {
            var items = await databaseContext.CartItems.Where(x => x.Product.Id == id).ToListAsync();
            var result = new List<Order>();
            foreach (var item in items)
            {
                var resultItem = await databaseContext.Orders.Include(x => x.Items).ThenInclude(x => x.Product).FirstOrDefaultAsync(x => x.Items.Contains(item));
                if(resultItem != null)
                    result.Add(resultItem);
            }
            return result;
        }

        public async Task DeleteAsync(Guid id, string userId)
        {
            var order = await databaseContext.Orders
                .Include(x => x.UserContacts)
                .Include(x=> x.UserContacts)
                .Include(x=> x.Items)
                .FirstOrDefaultAsync(x => x.Id == id);
            databaseContext.Orders.RemoveRange(order);
            await databaseContext.SaveChangesAsync();
        }

        public async Task AddAsync(Guid id, string userId)
        {
            var cart = await databaseContext.Carts.FirstOrDefaultAsync(x => x.Id == id || (userId != null && x.UserId == userId));
            var order = new Order(cart.Items);
            order.UserId = userId;
            databaseContext.Orders.Add(order);
            databaseContext.Carts.Remove(cart);
            await databaseContext.SaveChangesAsync();
        }

        public async Task<int> GetCountAsync()
        {
            return await databaseContext.Orders.CountAsync();
        }

        public Task Add(Order order, Cart cart)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetByIdAsync(Guid? id = null, string userId = null)
        {
            throw new NotImplementedException();
        }
    }
}
