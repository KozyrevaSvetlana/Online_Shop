using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Models
{
    public interface IProduct
    {
        IEnumerable<Product> AllProducts { get; }
    }
}
