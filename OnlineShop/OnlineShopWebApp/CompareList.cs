using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class CompareList
    {
        private static List<Product> compareList = new List<Product>();

        public static void Add(Product product)
        {
            var allProducts = ProductsRepository.GetAll();
            var result = allProducts.FirstOrDefault(x => x.Id == product.Id);
            compareList.Add(result);
        }
        public static List<Product> GetCompareList()
        {
            return compareList;
        }
        public static void Delete(int idProduct)
        {
            var product = compareList.FirstOrDefault(x => x.Id == idProduct);
            compareList.Remove(product);
        }
        public static void Clear()
        {
            compareList.Clear();
        }
    }
}
