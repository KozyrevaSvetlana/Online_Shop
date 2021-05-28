using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsersRepository usersRepository;
        private readonly IRolesRepository rolesRepository;

        public LoginController(IUsersRepository usersRepository, IRolesRepository rolesRepository)
        {
            this.usersRepository = usersRepository;
            this.rolesRepository = rolesRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult RegIndex()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckIn(Login login)
        {
            if (login.Name == login.Password)
            {
                ModelState.AddModelError("", "Имя и пароль не должны совпадать");
            }
            if (usersRepository.Contains(login.Name))
            {
                var user = usersRepository.GetUserByName(login.Name);
                if (login.Password != user.Login.Password)
                {
                    ModelState.AddModelError("", "Вы ввели неверный пароль");
                }
                else
                {
                    Constants.UserId = login.Name;
                    return View("Result", user);
                }
            }
            else
            {
                ModelState.AddModelError("", "Вы ввели неверное имя");
            }
            return View("Index", login);
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
