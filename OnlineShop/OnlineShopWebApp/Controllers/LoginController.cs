using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsersRepository usersRepository;

        public LoginController(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckIn(User user, bool rememberMe)
        {
            if (rememberMe)
            {
                usersRepository.AddUser(user);
            }
            return RedirectToAction("Result");
        }
        public string Result()
        {
            return "удачно";
        }
    }
}
