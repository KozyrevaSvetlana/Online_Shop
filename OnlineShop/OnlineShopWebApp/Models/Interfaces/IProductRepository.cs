using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Models.Interfaces
{
    interface IProductRepository
    {
        IEnumerable<List<Product>> AllProducts { get; }
    }
}
