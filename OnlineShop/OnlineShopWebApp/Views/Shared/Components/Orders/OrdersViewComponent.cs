using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Views.Shared.ViewComponents.OrdersViewComponent
{
    public class OrdersViewComponent : ViewComponent
    {
        private readonly IOrdersRepository ordersRepository;

        public OrdersViewComponent(IOrdersRepository ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }

        public IViewComponentResult Invoke()
        {
            var orders = ordersRepository.AllOrders;
            return View("Orders", orders);
        }
    }
}
