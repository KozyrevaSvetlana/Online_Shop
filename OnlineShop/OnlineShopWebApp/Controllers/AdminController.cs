using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Controllers
{
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

        public IActionResult Index()
        {
            return View();
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
                return RedirectToAction("Index", "Admin");
            }
            return View("EditForm", editProduct);
        }
        public ActionResult DeleteProduct(int id)
        {
            productsRepository.DeleteItem(id);
            return RedirectToAction("Index", "Admin");
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
                return RedirectToAction("Index", "Admin");
            }
            return RedirectToAction("Index", "Admin");
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
            return RedirectToAction("Index", "Admin");
        }
        public ActionResult DeleteOrder(int number)
        {
            ordersRepository.Delete(number);
            return RedirectToAction("Index", "Admin");
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
            }
            if (ModelState.IsValid)
            {
                rolesRepository.Add(newRole.Name);
                return RedirectToAction("Index", "Admin");
            }
            return RedirectToAction("Index", "Admin");
        }
        public ActionResult DeleteRole(string name)
        {
            rolesRepository.DeleteRole(name);
            return RedirectToAction("Index", "Admin");
        }

        public ActionResult EditRole(string name)
        {
            return View(rolesRepository.GetRoleByName(name));
        }


        public IActionResult ChangeRole(string ChangedName, string oldName)
        {
            var resultErrors = rolesRepository.IsValid(ChangedName);
            if (resultErrors.Count != 0)
            {
                foreach (var error in resultErrors)
                {
                    ModelState.AddModelError("", error);
                }
            }
            if (ModelState.IsValid)
            {
                rolesRepository.Edit(ChangedName, oldName);
                return RedirectToAction("Index", "Admin");
            }
            return RedirectToAction("Index", "Admin");






        }
    }
}
