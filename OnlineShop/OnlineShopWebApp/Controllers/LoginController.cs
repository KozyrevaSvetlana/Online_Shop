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
        public IActionResult CheckIn(Login user)
        {
            if (user.Name==user.Password)
            {
                ModelState.AddModelError("", "Имя и пароль не должны совпадать");
            }
            if (ModelState.IsValid)
            {
                return RedirectToAction("Result");
            }
            return View("Index");

        }
        public IActionResult Result()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Register user)
        {
            if (user.Name == user.FirstPassword)
            {
                ModelState.AddModelError("", "Имя и пароль не должны совпадать");
            }
            if (user.Name == user.CheckPassword)
            {
                ModelState.AddModelError("", "Имя и подтверждение пароля не должны совпадать");
            }
            if (ModelState.IsValid)
            {
                return RedirectToAction("Result");
            }
            return View("RegIndex");
        }
    }
}
