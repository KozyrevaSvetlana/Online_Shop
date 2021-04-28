
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class Basket
    {
        private List<BascetLine> productsLine = new List<BascetLine>();
        public void AddProduct(Product product, int count)
        {
            BascetLine bascetLine= productsLine
                .Where(p => p.Product.Id == product.Id)
                .FirstOrDefault();
            if (bascetLine == null)
            {
                productsLine.Add(new BascetLine
                {
                    Product = product,
                    Count = count
                });
            }
            else
            {
                bascetLine.Count += count;
            }
        }
        public void RemoveLine(Product product)
        {
            productsLine.RemoveAll(l => l.Product.Id == product.Id);
        }

        public decimal ComputeTotalValue()
        {
            return productsLine.Sum(e => e.Product.Cost * e.Count);

        }
        public void Clear()
        {
            productsLine.Clear();
        }

        public List<BascetLine> GetBascet()
        {
            return productsLine;
        }


        public class BascetLine
        {
            public Product Product { get; set; }
            public int Count { get; set; }
        }
    }
}
