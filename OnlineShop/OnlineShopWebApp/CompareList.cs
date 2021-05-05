using OnlineShopWebApp.Models;
using OnlineShopWebApp.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class CompareList : ICompareList
    {
        private List<Product> comparesList = new List<Product>();
        public void Add(Product product)
        {
            var sameProduct = comparesList.Any(x => x.Id == product.Id);
            if (!sameProduct)
            {
                comparesList.Add(product);
            }
        }
        public void Delete(Product product)
        {
            comparesList.RemoveAll(x => x.Id == product.Id);
        }
        public void Clear()
        {
            comparesList.Clear();
        }

        public IEnumerable<Product> AllCompareList
        {
            get
            {
                return comparesList;
            }
        }
    }
}
