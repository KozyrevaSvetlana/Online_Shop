using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Helper;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            return View(roleManager.Roles);
        }
        public async Task<IActionResult> AddRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> AddNewRoleAsync(IdentityRole newRole)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole { Name = newRole.Name };
                var result = await roleManager.CreateAsync(role);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                        return View("AddRole", newRole);
                    }
                }
            }
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> DeleteRoleAsync(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            var roles = roleManager.Roles;
            var usersInRole = await userManager.GetUsersInRoleAsync(role.Name);
            if (usersInRole.Count > 0)
            {
                string users = "";
                foreach (var user in usersInRole)
                {
                    users += $"{user.UserName}, ";
                }
                ModelState.AddModelError("", $"Роль невозможно удалить. Она используется {users.Substring(0, users.Length - 2)}.");
                return View("Index", roles);
            }
            await roleManager.DeleteAsync(role);
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> EditRoleAsync(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            return View(role.ToRoleViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> ChangeRoleAsync(string newName, string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);
            if (newName == null)
            {
                ModelState.AddModelError("", "Не заполнено новое имя");
                return View("EditRole", role);
            }
            if (newName.Length < 2 || newName.Length > 50)
            {
                ModelState.AddModelError("", "Имя должно быть не менее 2 символов и не более 50 символов");
                return View("EditRole", role);
            }
            role.Name = newName;
            var result = await roleManager.UpdateAsync(role);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return View("EditRole", role);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
