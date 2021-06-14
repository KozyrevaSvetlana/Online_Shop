using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager usersManager;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(IUsersManager usersManager, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.usersManager = usersManager;
            userManager = userManager;
            signInManager = signInManager;
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
                var result = _signInManager.PasswordSignInAsync(login.UserName, login.Password, login.RememberMe, false).Result;
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
            if (!usersRepository.IsUnique(user.Name))
            {
                ModelState.AddModelError("", "Такой пользователь уже существует");
            }
            if (ModelState.IsValid)
            {
                var role = rolesRepository.GetRoleByName("Пользователь");
                var newUser = CreateNewUser(user, role);
                Constants.UserId = user.Name;
                return View("Result", newUser);
            }
            return View("RegIndex");
        }

        private User CreateNewUser(Register user, Role role)
        {
            var userLogin = new Login();
            userLogin.Name = user.Name;
            userLogin.Password = user.FirstPassword;
            var newUser = new User(userLogin);
            newUser.AddRole(role);
            usersRepository.AddUser(newUser);
            return newUser;
        }
    }
}
