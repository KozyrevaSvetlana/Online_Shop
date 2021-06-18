using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Helpers;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class OrdersController : Controller
    {
        private readonly IOrdersRepository ordersRepository;

        public OrdersController(IOrdersRepository ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }
        public IActionResult Index()
        {
            return View(Mapping.ToOrdersViewModels(ordersRepository.AllOrders));
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
    }
}
