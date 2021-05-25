using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Views.Shared.ViewComponents.ProductsViewComponent
{
    public class RolesViewComponent : ViewComponent
    {
        private readonly IRolesRepository rolesRepository;

        public RolesViewComponent(IRolesRepository rolesRepository)
        {
            this.rolesRepository = rolesRepository;
        }

        public IViewComponentResult Invoke()
        {
            var roles = rolesRepository.AllRoles;
            return View("Roles", roles);
        }
    }
}
