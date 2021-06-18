using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class RolesController : Controller
    {
        RoleManager<IdentityRole> roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View(roleManager.Roles);
        }
        public ActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewRole(IdentityRole newRole)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole { Name = newRole.Name };
                var result = roleManager.CreateAsync(role).Result;
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                        return View("AddRole", newRole);
                    }
                }
            }
            return RedirectToAction("Roles", "Admin");
        }
        public ActionResult DeleteRole(string id)
        {
            var role = roleManager.FindByIdAsync(id).Result;
            var roles = roleManager.Roles;
            bool removePossible = false;
            foreach (var roleDb in roles)
            {
                removePossible = User.IsInRole(roleDb.Name);
                if (removePossible == true)
                {
                    ModelState.AddModelError("", $"Роль невозможно удалить. Она используется");
                    return RedirectToAction("Roles", "Admin", roleDb);
                }
            }
            roleManager.DeleteAsync(role).Wait();
            return RedirectToAction("Roles", "Admin");
        }
        public ActionResult EditRole(string id)
        {
            var role = roleManager.FindByIdAsync(id).Result;
            return View(role);
        }
        public IActionResult ChangeRole(IdentityRole newRole, string oldName)
        {
            var role = roleManager.FindByNameAsync(oldName).Result;
            role.Name = newRole.Name;
            var result = roleManager.UpdateAsync(role).Result;
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return View("EditRole", newRole);
                }
            }
            return RedirectToAction("Roles", "Admin");
        }
    }
}
