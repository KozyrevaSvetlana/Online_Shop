using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class CompareList
    {
        private static List<Product> compareList = new List<Product>();

        public static List<Product> GetCompareList()
        {
            return compareList;
        }

        public static void Add(Product product)
        {
            var allProducts = ProductsRepository.GetAll();
            var result = allProducts.FirstOrDefault(x => x.Id == product.Id);
            var sameProduct = compareList.Any(x => x.Id == result.Id);
            if (!sameProduct)
            {
                compareList.Add(result);
            }
        }
        public static void Delete(int productId)
        {
            compareList.RemoveAll(x => x.Id == productId);
        }
        public static void Clear()
        {
            compareList.Clear();
        }
    }
}
