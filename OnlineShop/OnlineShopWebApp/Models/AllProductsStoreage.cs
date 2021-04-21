using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public static class AllProductsStoreage
    {
        public static void Append(Product product)
        {
            var products = GetAll();
            products.Add(product);
        }
        public static List<Product> GetAll()
        {
            var products = new List<Product>();
            products.Add(new Product("Плюшевый мишка", 300, "Плюшевый мишка – символ нежности, трогательной заботы, " +
                "тепла. Многим он знаком с первых лет жизни. "));
            products.Add(new Product("Конструктор", 1000, "Любознательным малышам придется по душе конструктор."));
            products.Add(new Product("Пирамидка стаканчики", 200, "«Пирамидка собирается из стаканчиков разного размера. " +
                "Только соблюдая четкую последовательность от большего стаканчика к меньшему у малыша получится башенка"));
            products.Add(new Product("Водный пистолет", 150, "Длагодаря водному пистолету можно весело играть в друзьями летом на лужайке"));
            products.Add(new Product("Мяч детский", 170, "Мяч выполнен из прочного ПВХ и подходит для активных игр как дома, так и на воздухе"));
            return products;
        }
    }
}
