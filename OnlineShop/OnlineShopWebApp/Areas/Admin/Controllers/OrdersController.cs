using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Helpers;
using System;
using ModelsLibrary.Helper;
using System.Threading.Tasks;
using ModelsLibrary.Converters;
using ModelsLibrary.ModelsVM;
using static ModelsLibrary.ModelsVM.InfoStatusOrderViewModel;

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
            var orders = await ordersRepository.GetAllAsync();
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
            await ordersRepository.Edit(number, (int)EnumExtensions.GetValueFromDescription<Statuses>(status));
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            await ordersRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
