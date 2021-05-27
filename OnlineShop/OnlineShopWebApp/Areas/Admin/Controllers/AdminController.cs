using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly IOrdersRepository ordersRepository;
        private readonly IRolesRepository rolesRepository;
        private readonly IUsersRepository usersRepository;

        public AdminController(IProductsRepository products, IOrdersRepository ordersRepository, IRolesRepository rolesRepository, IUsersRepository usersRepository)
        {
            this.productsRepository = products;
            this.ordersRepository = ordersRepository;
            this.rolesRepository = rolesRepository;
            this.usersRepository = usersRepository;
        }
        public IActionResult Home()
        {
            return View();
        }
        public IActionResult Orders()
        {
            return View(ordersRepository.AllOrders);
        }
        public IActionResult Users()
        {
            return View(usersRepository.AllUsers);
        }
        public IActionResult Products()
        {
            return View(productsRepository.AllProducts);
        }
        public IActionResult Roles()
        {
            return View(rolesRepository.AllRoles);
        }
        public IActionResult Description(int id)
        {
            var result = productsRepository.GetProductById(id);
            return View(result);
        }
        public ActionResult EditForm(int id)
        {
            var result = productsRepository.GetProductById(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult EditProduct(Product editProduct)
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
                productsRepository.Edit(editProduct);
                return RedirectToAction("Products", "Admin");
            }
            return View("EditForm", editProduct);
        }
        public ActionResult DeleteProduct(int id)
        {
            productsRepository.DeleteItem(id);
            return RedirectToAction("Products", "Admin");
        }
        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewProduct(Product newProduct)
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
                productsRepository.Add(newProduct);
                return RedirectToAction("Products", "Admin");
            }
            return RedirectToAction("Products", "Admin");
        }
        public IActionResult OrderForm(int number)
        {
            var order = ordersRepository.GetOrderByNumber(number);
            ViewData["Statuses"] = order.InfoStatus.GetAllStatuses();
            return View(order);
        }
        public IActionResult EditOrder(int number, string status)
        {
            var order = ordersRepository.GetOrderByNumber(number);
            order.InfoStatus.ChangeStatus(status);
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
            var resultErrors = rolesRepository.IsValid(newRole.Name);
            if (resultErrors.Count != 0)
            {
                foreach (var error in resultErrors)
                {
                    ModelState.AddModelError("", error);
                }
                return View("AddRole", newRole);
            }
            if (ModelState.IsValid)
            {
                rolesRepository.Add(newRole.Name);
                return RedirectToAction("Roles", "Admin");
            }
            return RedirectToAction("Roles", "Admin");
        }
        public ActionResult DeleteRole(string name)
        {
            rolesRepository.DeleteRole(name);
            return RedirectToAction("Roles", "Admin");
        }
        public ActionResult EditRole(string name)
        {
            return View(rolesRepository.GetRoleByName(name));
        }
        public IActionResult ChangeRole(Role newRole, string oldName)
        {
            var resultErrors = rolesRepository.IsValid(newRole.Name);
            if (resultErrors.Count != 0)
            {
                foreach (var error in resultErrors)
                {
                    ModelState.AddModelError("", error);
                }
                return View("EditRole", newRole);
            }
            if (ModelState.IsValid)
            {
                rolesRepository.Edit(newRole.Name, oldName);
                return RedirectToAction("Roles", "Admin");
            }
            return RedirectToAction("Roles", "Admin");
        }
        public ActionResult AddUser()
        {
            return View();
        }
        public ActionResult UserInfo(string name)
        {
            return View(usersRepository.GetUserByName(name));
        }

        public ActionResult ChangePassword(string name)
        {
            return View(usersRepository.GetUserByName(name));
        }

        [HttpPost]
        public ActionResult AddNewPassword(string FirstPassword, string SecondPassword, User user)
        {
            if (FirstPassword!= SecondPassword)
            {
                ModelState.AddModelError("", "Пароли не совпадают");
                return View("ChangePassword", user);
            }
            if (ModelState.IsValid)
            {
                user.Login.Password = FirstPassword;
                return View("Users");
            }
            return View("ChangePassword", user);
        }
        public ActionResult DeleteUser(string name)
        {
            var user = usersRepository.GetUserByName(name);
            usersRepository.DeleteUser(user);
            return View("Users");
        }
    }
}
