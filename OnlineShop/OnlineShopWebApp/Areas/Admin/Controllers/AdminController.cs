using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly IOrdersRepository ordersRepository;
        private readonly IRolesRepository rolesRepository;

        public AdminController(IProductsRepository products, IOrdersRepository ordersRepository, IRolesRepository rolesRepository)
        {
            this.productsRepository = products;
            this.ordersRepository = ordersRepository;
            this.rolesRepository = rolesRepository;
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
            return View();
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
        [Area("Admin")]
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
    }
}
