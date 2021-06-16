using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IOrdersRepository ordersRepository;

        public LoginController(UserManager<User> userManager, SignInManager<User> signInManager, IOrdersRepository ordersRepository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.ordersRepository = ordersRepository;
        }

        public IActionResult Index(string returnUrl)
        {
            if (returnUrl != null)
            {
                return View(new Login() { ReturnUrl = returnUrl });
            }
            return View();
        }
        public IActionResult RegIndex()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegIndex(Login login)
        {
            return View(new Register() { ReturnUrl = login.ReturnUrl });
        }

        [HttpPost]
        public IActionResult CheckIn(Login login)
        {
            if (ModelState.IsValid)
            {
                var result = signInManager.PasswordSignInAsync(login.Name, login.Password, login.RememberMe, false).Result;
                if (result.Succeeded)
                {
                    if (login.ReturnUrl == null)
                    {
                        return RedirectToAction(nameof(HomeController.Index), "Home");
                    }
                    return Redirect(login.ReturnUrl);
                    //if (login.ReturnUrl!="")
                    //{
                    //}
                    //else
                    //{
                    //    var userDb = userManager.FindByNameAsync(login.Name).Result;
                    //    var lastOrder = ordersRepository.GetLastOrder(userDb.UserName);
                    //    var user = new UserViewModel() { Login = login, Id=userDb.Id, Orders=new lis };
                    //    return RedirectToAction("Result");
                    //}
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
                    if (register.ReturnUrl == null)
                    {
                        return RedirectToAction(nameof(HomeController.Index), "Home");
                    }
                    return View(register.ReturnUrl);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                        return View("RegIndex", register);
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
