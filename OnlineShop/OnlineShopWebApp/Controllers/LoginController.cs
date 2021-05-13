using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class LoginController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult RegIndex()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckIn(User user)
        {
            return RedirectToAction("Result");
        }
        public IActionResult Result()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(NewUser user)
        {
            return RedirectToAction("Result");
        }

    }
}
