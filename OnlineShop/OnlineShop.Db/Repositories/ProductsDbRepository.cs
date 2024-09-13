using Microsoft.EntityFrameworkCore;
using ModelsLibrary.ModelsDto;
using OnlineShop.Db.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Db.Repositories
{
    public class ProductsDbRepository : IProductsRepository
    {
        private readonly IdentityContext databaseContext;
        public ProductsDbRepository(IdentityContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await databaseContext.Products
                .Include(x => x.Images)
                .ToListAsync();
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await databaseContext.Products
                .Include(x => x.Images)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task DeleteAsync(Guid id, string userId = null)
        {
            var product = await GetByIdAsync(id);
            var cartitems = await databaseContext.CartItems
                .Include(x => x.Product)
                .ThenInclude(x => x.Images)
                .Where(x => x.Id == product.Id)
                .ToListAsync();
            databaseContext.CartItems.RemoveRange(cartitems);
            databaseContext.Products.Remove(product);
            await databaseContext.SaveChangesAsync();
        }
        public async Task AddAsync(Guid id, string userId)
        {
            var product = await databaseContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            databaseContext.Products.Add(product);
            await databaseContext.SaveChangesAsync();
        }

        public async Task<List<Product>> Search(string[] words)
        {
            var result = new HashSet<Product>();

            foreach (var word in words)
            {
                (await databaseContext.Products
                    .Where(x => x.Name.ToLower().Contains(word.ToLower()))
                    .Include(x => x.Images)
                    .ToListAsync())?
                    .ForEach(x => result.Add(x));
            }
            return result.ToList();
        }

        public async Task EditAsync(Product editProduct)
        {
            var product = await GetByIdAsync(editProduct.Id);
            product.Name = editProduct.Name;
            product.Cost = editProduct.Cost;
            product.Description = editProduct.Description;
            product.Images = editProduct.Images;
            await databaseContext.SaveChangesAsync();
        }

        public async Task<int> GetCountAsync(string userId)
        {
            return await databaseContext.Products.CountAsync();
        }

        public async Task CreateAsync(Product product)
        {
            if (await databaseContext.Products.ContainsAsync(product))
            {
                throw new Exception("Такой товар уже добавлен");
            }
            await databaseContext.Products.AddAsync(product);
            await databaseContext.SaveChangesAsync();
        }

        public async Task<Product> GetByIdAsync(Guid? id = null, string userId = null)
        {
            return await databaseContext.Products
                .Include(x => x.Images)
                .Include(x => x.Compares)
                .Include(x => x.Orders)
                .Include(x => x.Favorites)
                .Include(x => x.CartItems)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<(List<Product>, int)> Paginate(int take, int? page)
        {
            (List<Product>, int) result;
            result.Item1 = await databaseContext.Products
                .Include(x => x.Images)
                .Skip((page ?? 1) * take)
                .Take(take)
                .ToListAsync();
            result.Item2 = await databaseContext.Products.CountAsync();
            return result;
        }
    }
}
