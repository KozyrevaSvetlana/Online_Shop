﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class AdminController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly IOrdersRepository ordersRepository;
        private readonly UserManager<User> userManager;

        public AdminController(IProductsRepository products, IOrdersRepository ordersRepository, IRolesRepository rolesRepository, IUsersRepository usersRepository,
            UserManager<User> userManager, SignInManager<User> signInManager)
        {
            productsRepository = products;
            this.ordersRepository = ordersRepository;
            this.userManager = userManager;
        }
        public IActionResult Home()
        {
            return View();
        }
        public IActionResult Orders()
        {
            return View(Mapping.ToOrdersViewModels(ordersRepository.AllOrders));
        }
        public IActionResult Users()
        {
            //usersRepository.AllUsers
            return View();
        }
        public IActionResult Products()
        {
            return View(Mapping.ToProductViewModels(productsRepository.AllProducts));
        }
        public IActionResult Roles()
        {
            //rolesRepository.AllRoles
            return View();
        }
        public IActionResult Description(Guid id)
        {
            var result = productsRepository.GetProductById(id);
            return View(Mapping.ToProductViewModel(result));
        }
        public ActionResult EditForm(Guid id)
        {
            var result = productsRepository.GetProductById(id);
            return View(Mapping.ToProductViewModel(result));
        }
        [HttpPost]
        public ActionResult EditProduct(ProductViewModel editProduct)
        {
            var validResult = editProduct.IsValid();
            if (validResult.Count != 0)
            {
                foreach (var errors in validResult)
                {
                    ModelState.AddModelError("", errors);
                }
            }
            if (ModelState.IsValid)
            {
                var productDb = new Product
                {
                    Name = editProduct.Name,
                    Cost = editProduct.Cost,
                    Description = editProduct.Description,
                    Image = editProduct.Image
                };
                productsRepository.Edit(productDb);
                return RedirectToAction("Products", "Admin");
            }
            return View("EditForm", editProduct);
        }
        public ActionResult DeleteProduct(Guid id)
        {
            productsRepository.DeleteItem(id);
            return RedirectToAction("Products", "Admin");
        }
        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewProduct(ProductViewModel newProduct)
        {
            var errorsResult = newProduct.IsValid();
            if (errorsResult.Count != 0)
            {
                foreach (var error in errorsResult)
                {
                    ModelState.AddModelError("", error);
                }
                return View("AddProduct", newProduct);
            }
            if (ModelState.IsValid)
            {
                var productDb = new Product
                {
                    Name = newProduct.Name,
                    Cost = newProduct.Cost,
                    Description = newProduct.Description,
                    Image = newProduct.Image
                };
                productsRepository.Add(productDb);
                return RedirectToAction("Products", "Admin");
            }
            return RedirectToAction("Products", "Admin");
        }
        public IActionResult OrderForm(int number)
        {
            var order = ordersRepository.GetOrderByNumber(number);
            ViewData["Statuses"] = Mapping.ToOrderViewModels(order).InfoStatus.GetAllStatuses();
            return View(Mapping.ToOrderViewModels(order));
        }
        public IActionResult EditOrder(int number, string status)
        {
            ordersRepository.Edit(number, Mapping.ToIntStatus(status));
            return RedirectToAction("Orders", "Admin");
        }
        public ActionResult DeleteOrder(int number)
        {
            ordersRepository.Delete(number);
            return RedirectToAction("Orders", "Admin");
        }
        public ActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewRole(Role newRole)
        {
            //var resultErrors = rolesRepository.IsValid(newRole.Name);
            //if (resultErrors.Count != 0)
            //{
            //    foreach (var error in resultErrors)
            //    {
            //        ModelState.AddModelError("", error);
            //    }
            //    return View("AddRole", newRole);
            //}
            //if (ModelState.IsValid)
            //{
            //    //rolesRepository.Add(newRole.Name);
            //    return RedirectToAction("Roles", "Admin");
            //}
            return RedirectToAction("Roles", "Admin");
        }
        public ActionResult DeleteRole(string name)
        {
            //rolesRepository.DeleteRole(name);
            return RedirectToAction("Roles", "Admin");
        }
        public ActionResult EditRole(string name)
        {
            //rolesRepository.GetRoleByName(name)
            return View();
        }
        public IActionResult ChangeRole(Role newRole, string oldName)
        {
            //var resultErrors = rolesRepository.IsValid(newRole.Name);
            //if (resultErrors.Count != 0)
            //{
            //    foreach (var error in resultErrors)
            //    {
            //        ModelState.AddModelError("", error);
            //    }
            //    return View("EditRole", newRole);
            //}
            //if (ModelState.IsValid)
            //{
            //    rolesRepository.Edit(newRole.Name, oldName);
            //    return RedirectToAction("Roles", "Admin");
            //}
            return RedirectToAction("Roles", "Admin");
        }
        public ActionResult AddUser()
        {
            return View();
        }
        public ActionResult UserInfo(string name)
        {
            var user = userManager.FindByNameAsync(name).Result;
            //сделать маппинг и передать во вью
            return View();
        }

        public ActionResult ChangePassword(string name)
        {
            var user = userManager.FindByNameAsync(name).Result;
            //сделать маппинг и передать во вью user.Login
            return View();
        }

        [HttpPost]
        public ActionResult AddNewPassword(Login login, string CheckPassword, string userName)
        {
            var user = userManager.FindByNameAsync(userName).Result;
            if (login.Password != CheckPassword)
            {
                ModelState.AddModelError("", "Пароли не совпадают");
                // наверное тут должен быть какой то специальный метод вместо user.Login
                return View("ChangePassword");
            }
            //if (login.Password == user.Login.Password)
            //{
            //    ModelState.AddModelError("", "Старый и новый пароли совпадают");
            //    return View("ChangePassword", user.Login);
            //}
            //if (ModelState.IsValid)
            //{
            //    user.Login.Password = login.Password;
            //}
            return RedirectToAction("Users");
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
            //ViewData["Roles"] = rolesRepository.AllRoles;
            return View(user);
        }
        [HttpPost]
        public ActionResult EditUserInfo(UserViewModel editUser, string id)
        {
            //var user = usersRepository.GetUserById(id);
            //user.UpdateUser(editUser);
            return RedirectToAction("Users", "Admin");
        }
    }
}
