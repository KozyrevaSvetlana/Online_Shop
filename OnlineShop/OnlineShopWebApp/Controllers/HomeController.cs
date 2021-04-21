using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public static string Index()
        {
            StringBuilder results = new StringBuilder();
            var allProducts = new List<Product>();
            allProducts = GeTAll();
            //products.Add(new Product("Плюшевый мишка", 300, "Плюшевый мишка – символ нежности, трогательной заботы, " +
            //    "тепла. Многим он знаком с первых лет жизни. "));
            //products.Add(new Product("Конструктор", 1000, "Любознательным малышам придется по душе конструктор."));
            //products.Add(new Product("Пирамидка стаканчики", 200, "«Пирамидка собирается из стаканчиков разного размера. " +
            //    "Только соблюдая четкую последовательность от большего стаканчика к меньшему у малыша получится башенка"));
            //products.Add(new Product("Водный пистолет", 150, "Длагодаря водному пистолету можно весело играть в друзьями летом на лужайке"));
            //products.Add(new Product("Мяч детский", 170, "Мяч выполнен из прочного ПВХ и подходит для активных игр как дома, так и на воздухе"));
            foreach (var product in allProducts)
            {
                results.Append(product);
                results.Append("");
            }
            return results.ToString();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
