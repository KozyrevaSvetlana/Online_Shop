using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class startController : Controller
    {
        public string hello()
        {
            DateTime now = new DateTime();
            now = DateTime.Now;
            string result = "пустая строка";
            int timeResult = now.Hour / 6;
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
