using Microsoft.AspNetCore.Mvc;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class StartController : Controller
    {
        public string Hello()
        {
            var now = DateTime.Now;
            var result = "пустая строка";
            var timeResult = now.Hour / 6;
            switch (timeResult)
            {
                case 0:
                    result = "Доброй ночи";
                    break;
                case 1:
                    result = "Доброе утро";
                    break;
                case 2:
                    result = "Добрый день";
                    break;
                case 3:
                    result = "Добрый вечер";
                    break;
            }
            return result;
        }
    }
}
