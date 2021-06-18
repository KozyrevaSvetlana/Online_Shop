using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class UsersController : Controller
    {
        private readonly UserManager<User> userManager;

        public UsersController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            var allusers = userManager.Users;
            return View(allusers.ToListUserViewModels());
        }
        public ActionResult AddUser()
        {
            return View();
        }
        public ActionResult UserInfo(string name)
        {
            var user = userManager.FindByNameAsync(name).Result;
            return View(user.ToUserViewModel());
        }

        public ActionResult ChangePassword(string userName)
        {
            var user = userManager.FindByNameAsync(userName).Result;
            return View(user.ToUserViewModel().Login);
        }

        [HttpPost]
        public ActionResult AddNewPassword(Login login, string CheckPassword, string userName, string oldPassword)
        {
            var user = userManager.FindByNameAsync(userName).Result;
            bool validPassword = userManager.CheckPasswordAsync(user, oldPassword).Result;
            if (!validPassword)
            {
                ModelState.AddModelError("", "Старый пароль указан неверно");
                return View("ChangePassword", login);
            }
            if (login.Password != CheckPassword)
            {
                ModelState.AddModelError("", "Пароли не совпадают");
                return View("ChangePassword", login);
            }
            var result = userManager.ChangePasswordAsync(user, oldPassword, login.Password).Result;
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return View("ChangePassword", login);
                }
            }
            userManager.ChangePasswordAsync(user, oldPassword, login.Password).Wait();
            userManager.UpdateAsync(user).Wait();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteUser(string name)
        {
            var user = userManager.FindByNameAsync(name).Result;
            // должен быть какой то метод удаления юзера или пометки что удален в userManager
            //usersRepository.DeleteUser(user);
            return View("Users");
        }
        public ActionResult EditUser(string name)
        {
            var user = userManager.FindByNameAsync(name).Result;
            return View(user.ToUserViewModel());
        }
        [HttpPost]
        public ActionResult EditUserInfo(UserViewModel editUser, string id)
        {
            var user = userManager.FindByIdAsync(id).Result;
            user.ChangeContactsUser(editUser.Contacts);
            userManager.UpdateAsync(user).Wait();
            return RedirectToAction("Users", "Admin");
        }
    }
}
