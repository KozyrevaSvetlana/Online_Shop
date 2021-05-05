using OnlineShopWebApp.Models;
using OnlineShopWebApp.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class ComparesList : IComparesList
    {
        private readonly IProductsRepository productsRepository;
        public ComparesList(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }
        private List<Product> comparesList = new List<Product>();
        public void Add(Product product)
        {
            var allProducts = productsRepository.AllProducts;
            var result = allProducts.FirstOrDefault(x => x.Id == product.Id);
            var sameProduct = comparesList.Any(x => x.Id == result.Id);
            if (!sameProduct)
            {
                comparesList.Add(result);
            }
        }
        public void Delete(int productId)
        {
            comparesList.RemoveAll(x => x.Id == productId);
        }
        public void Clear()
        {
            comparesList.Clear();
        }
        public IEnumerable<Product> _comparesList
        {
            get
            {
                return comparesList;
            }
        }
    }
}
