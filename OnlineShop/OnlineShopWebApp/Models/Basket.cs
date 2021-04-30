
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class Basket
    {
        private static List<BasketList> productsLine = new List<BasketList>();
        public static void AddProduct(BasketList basketList)
        {
            var result = productsLine.FirstOrDefault(x => x.Product.Id == basketList.Product.Id);
            if (result == null)
            {
                productsLine.Add(basketList);
            }
            else
            {
                result.Count++;
            }
            BasketRepository.Save(productsLine);
        }
        public void RemoveLine(Product product)
        {
            productsLine.RemoveAll(x => x.Product.Id == product.Id);
        }
        public void Clear()
        {
            productsLine.Clear();
            BasketRepository.Save(productsLine);
        }
        public static List<BasketList> GetBascet()
        {
            return productsLine;
        }
        public class BasketList
        {
            public Product Product { get; set; }
            public int Count = 0;
            public BasketList(int id)
            {
                var allProducts = ProductsStorage.GetAllProducts();
                Product = allProducts.FirstOrDefault(x => x.Id == id);
                Count++;
            }
        }
    }
}
