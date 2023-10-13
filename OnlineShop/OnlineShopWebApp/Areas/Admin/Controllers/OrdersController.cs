using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Helper;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Helpers;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Index()
        {
            var orders = await ordersRepository.GetAll();
            return View(orders.ToOrdersViewModels());
        }
        public async Task<IActionResult> OrderForm(int number)
        {
            var order = await ordersRepository.GetByNumber(number);
            ViewData["Statuses"] = order.ToOrderViewModels().InfoStatus.GetAllStatuses();
            return View(order.ToOrderViewModels());
        }
        public async Task<IActionResult> EditOrder(int number, string status)
        {
            await ordersRepository.Edit(number, Mapping.ToIntStatus(status));
            return RedirectToAction("Orders", "Admin");
        }
        public async Task<IActionResult> DeleteOrder(int number)
        {
            await ordersRepository.Delete(number);
            return RedirectToAction("Orders", "Admin");
        }
    }
}
