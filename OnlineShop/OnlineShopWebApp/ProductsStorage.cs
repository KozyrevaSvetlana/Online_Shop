﻿using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public static class ProductsStorage
    {
        private static List<Product> allProducts = new List<Product>();
        public static List<Product> Get()
        {
            if (allProducts.Count == 0)
            {
                allProducts.Add(new Product("Плюшевый мишка", 300, "Плюшевый мишка – символ нежности, трогательной заботы, " +
"тепла. Многим он знаком с первых лет жизни.", "/img/Products/1.jpg"));
                allProducts.Add(new Product("Конструктор", 1000, "Любознательным малышам придется по душе конструктор.", "/img/Products/2.jpg"));
                allProducts.Add(new Product("Пирамидка стаканчики", 200, "«Пирамидка собирается из стаканчиков разного размера. " +
    "Только соблюдая четкую последовательность от большего стаканчика к меньшему у малыша получится башенка", "/img/Products/3.jpg"));
                allProducts.Add(new Product("Водный пистолет", 150, "Длагодаря водному пистолету можно весело играть в друзьями летом на лужайке", "/img/Products/4.jpg"));
                allProducts.Add(new Product("Мяч детский", 170, "Мяч выполнен из прочного ПВХ и подходит для активных игр как дома, так и на воздухе", "/img/Products/5.jpg"));
            }
            return allProducts;
        }
        public static void AppendProduct(Product product)
        {
            allProducts.Add(product);
        }
        public static List<Product> GetAllProducts()
        {
            return Get();
        }
    }
}
