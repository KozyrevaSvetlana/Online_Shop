using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Models;
using System.Threading.Tasks;

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
        public IActionResult RegIndex(string returnUrl)
        {
            if (returnUrl != null)
            {
                return View(new Register() { ReturnUrl = returnUrl });
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CheckInAsync(Login login)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(login.Name, login.Password, login.RememberMe, false);
                if (result.Succeeded)
                {
                    if (login.ReturnUrl == null)
                    {
                        return RedirectToAction(nameof(HomeController.Index), "Home");
                    }
                    return Redirect(login.ReturnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный пароль");
                }
            }
            return View("Index", login);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(Register register)
        {
            if (register.Name == register.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать!");
            }
            if (ModelState.IsValid)
            {
                User user = new User { UserName = register.Name };
                var result = await userManager.CreateAsync(user, register.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    if (register.ReturnUrl == null)
                    {
                        return RedirectToAction(nameof(HomeController.Index), "Home");
                    }
                    return Redirect(register.ReturnUrl);
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
            return View("RegIndex", register);
        }
        public IActionResult Logout()
        {
            signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
