using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class ProductsRepository
    {
        private static List<Product> products = new List<Product>()
        {
            new Product("Плюшевый мишка", 300, "Плюшевый мишка – символ нежности, трогательной заботы, " +
"тепла. Многим он знаком с первых лет жизни.", "/img/Products/1.jpg"),
            new Product("Конструктор", 1000, "Любознательным малышам придется по душе конструктор.", "/img/Products/2.jpg"),
            new Product("Пирамидка стаканчики", 200,"Пирамидка собирается из стаканчиков разного размера. " +
                "Только соблюдая четкую последовательность от большего стаканчика к меньшему у малыша получится башенка","/img/Products/3.jpg"),
            new Product("Водный пистолет", 150, "Длагодаря водному пистолету можно весело играть в друзьями летом на лужайке", "/img/Products/4.jpg"),
                new Product("Мяч детский", 170, "Мяч выполнен из прочного ПВХ и подходит для активных игр как дома, так и на воздухе", "/img/Products/5.jpg")
    };
        public static List<Product> GetAll()
        {
            return products;
        }

        public Product TryGetById(int id)
        {
            return products.FirstOrDefault(product => product.Id == id);
        }
    }
}
