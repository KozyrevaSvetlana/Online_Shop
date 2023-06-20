using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class UsersController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IOrdersRepository ordersRepository;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<User> signInManager;

        public UsersController(UserManager<User> userManager, IOrdersRepository ordersRepository, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.ordersRepository = ordersRepository;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
            var allUsers = userManager.Users;
            return View(allUsers.ToListUserViewModels());
        }
        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> AddUserAsync(Register register)
        {
            if (register.Name == register.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать!");
                return View("AddUser", register);
            }
            if (ModelState.IsValid)
            {
                User newUser = new User { UserName = register.Name };
                var result = await userManager.CreateAsync(newUser, register.Password);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                        return View("AddUser", register);
                    }
                }
                var resultRole = await userManager.AddToRoleAsync(newUser, "user");
                if (resultRole.Succeeded)
                {
                    userManager.AddToRoleAsync(newUser, "user");
                }
            }
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> UserInfoAsync(string name)
        {
            var user = await userManager.FindByNameAsync(name);
            return View(user.ToUserViewModel());
        }

        public async Task<ActionResult> ChangePasswordAsync(string userName)
        {
            var user = await userManager.FindByNameAsync(userName);
            return View(user.ToUserViewModel().Login);
        }

        [HttpPost]
        public async Task<ActionResult> AddNewPasswordAsync(Login login, string CheckPassword, string userName, string oldPassword)
        {
            var user = await userManager.FindByNameAsync(userName);
            bool validPassword = await userManager.CheckPasswordAsync(user, oldPassword);
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
            var result = await userManager.ChangePasswordAsync(user, oldPassword, login.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return View("ChangePassword", login);
                }
            }
            await userManager.ChangePasswordAsync(user, oldPassword, login.Password);
            await userManager.UpdateAsync(user);
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> DeleteUserAsync(string name)
        {
            var user = await userManager.FindByNameAsync(name);
            var orders = await ordersRepository.GetOrdersByUserId(user.UserName);
            if (orders.Any())
            {
                string ordersNumbers = "";
                foreach (var order in orders)
                {
                    ordersNumbers += $"{order.Number}, ";
                }
                ModelState.AddModelError("", $"Невозможно удалить пользователя {user.UserName}. " +
                    $"У него есть заказы: {ordersNumbers.Substring(0, ordersNumbers.Length - 2)}.");
                var allUsers = userManager.Users;
                return View("Index", allUsers.ToListUserViewModels());
            }
            var result = await userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return RedirectToAction("Index");
                }
            }
            await userManager.DeleteAsync(user);
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> EditFormAsync(string name)
        {
            var user = await userManager.FindByNameAsync(name);
            ViewBag.Id = user.Id;
            return View(user.ToUserViewModel().Contacts);
        }
        [HttpPost]
        public async Task<ActionResult> ChangeContactsAsync(UserContactViewModel editUser, string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            user.ChangeContactsUser(editUser);
            var result = await userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return View("EditForm", editUser);
                }
            }
            userManager.UpdateAsync(user);
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> RolesAsync(string userName)
        {
            User user = await userManager.FindByNameAsync(userName);
            var allRoles = roleManager.Roles;
            var model = new ChangeRoleViewModel();
            model.UserName = user.UserName;
            model.AllRoles = allRoles.ToListRoleViewModel();
            var userRoles = new List<RoleViewModel>();
            try
            {
                var userRolesDb = await userManager.GetRolesAsync(user);
                model.UserRoles = userRolesDb.Select(x => new RoleViewModel { Name = x }).ToList();

            }
            catch (Exception)
            {
                userRoles = new List<RoleViewModel>();
            }
            return View(model);
        }
        public async Task<ActionResult> EditAsync(string userName, List<string> roles)
        {
            if (roles.Count == 0)
            {
                ModelState.AddModelError("", "Вы не выбрали роль");
                var model = new ChangeRoleViewModel();
                model.UserName = userName;
                var allRoles = roleManager.Roles;
                model.AllRoles = allRoles.ToListRoleViewModel();
                return View("Roles", model);
            }
            var user = await userManager.FindByNameAsync(userName);
            var userRoles = await userManager.GetRolesAsync(user);
            var addedRoles = roles.Except(userRoles);
            var removedRoles = userRoles.Except(roles);
            await userManager.RemoveFromRolesAsync(user, removedRoles);
            await userManager.AddToRolesAsync(user, addedRoles);
            await userManager.UpdateAsync(user);
            return RedirectToAction("Index");
        }
    }
}
