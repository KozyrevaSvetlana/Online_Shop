using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsersRepository usersRepository;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public LoginController(IUsersRepository usersRepository, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.usersRepository = usersRepository;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Index(string returnUrl)
        {
            return View(new Login() {ReturnUrl= returnUrl });
        }
        public IActionResult RegIndex()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckIn(Login login)
        {
            if (ModelState.IsValid)
            {
                var result = signInManager.PasswordSignInAsync(login.Name, login.Password, login.RememberMe, false).Result;
                if (result.Succeeded)
                {
                    return Redirect(login.ReturnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный пароль");
                }
            }

            return View(login);
        }
        public IActionResult Result(User user)
        {
            return View(user);
        }
        [HttpPost]
        public IActionResult Create(Register register)
        {
            if (register.Name == register.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать!");
            }

            if (ModelState.IsValid)
            {
                User user = new User { UserName = register.Name };
                // добавляем пользователя
                var result = userManager.CreateAsync(user, register.Password).Result;
                if (result.Succeeded)
                {
                    // установка куки
                    signInManager.SignInAsync(user, false).Wait();
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(register);
        }
        public IActionResult Logout()
        {
            signInManager.SignOutAsync().Wait();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
