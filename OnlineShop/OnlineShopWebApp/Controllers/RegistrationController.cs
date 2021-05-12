using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(NewUser user)
        {
            return RedirectToAction("Result");
        }
        public IActionResult Result()
        {
            return View();
        }
    }
}
