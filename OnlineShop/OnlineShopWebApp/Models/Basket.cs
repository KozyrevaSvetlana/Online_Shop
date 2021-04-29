
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class Basket
    {
        private static List<BasketList> productsLine = new List<BasketList>();
        public void AddProduct(BasketList basketList)
        {
            if (productsLine == null)
            {
                productsLine.Add(basketList);
            }
            else
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
            }
        }

        public void RemoveLine(Product product)
        {
            productsLine.RemoveAll(x => x.Product.Id == product.Id);
        }

        public decimal ComputeTotalValue()
        {
            return productsLine.Sum(x => x.Product.Cost * x.Count);

        }
        public void Clear()
        {
            productsLine.Clear();
        }

        public static List<BasketList> GetBascet()
        {
            return productsLine;
        }

        private void AddAllProducts()
        {
            var allProducts = ProductsStorage.GetAllProducts();
            foreach (var item in allProducts)
            {
                BasketList basket = new BasketList(item);
                AddProduct(basket);
            }
        }
        public class BasketList
        {
            public Product Product { get; set; }
            public int Count = 0;
            public BasketList(Product product)
            {
                Product = product;
                Count++;
            }
        }
    }
}
