using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IFavoritesRepository favoritesRepository;
        private readonly IOrdersRepository ordersRepository;

        public ProfileController(IFavoritesRepository favoritesRepository, IOrdersRepository ordersRepository, UserManager<User> userManager)
        {
            this.favoritesRepository = favoritesRepository;
            this.ordersRepository = ordersRepository;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Orders()
        {
            var userDb = userManager.GetUserAsync(HttpContext.User).Result;
            var orders = ordersRepository.GetOrdersByUserId(userDb.UserName);
            var userVM = userDb.ToUserViewModel();
            userVM.Orders = orders.ToOrdersViewModels();
            return View(userVM);
        }
        public IActionResult Contacts()
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            var emptyContacts = user.ToUserViewModel().GetEmptyContacts();
            if (emptyContacts.Count != 0)
            {
                ViewBag.Empty = emptyContacts;
            }
            return View(user.ToUserViewModel());
        }
        public IActionResult AddContacts()
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            return View(user.ToUserViewModel().Contacts);
        }

        [HttpPost]
        public IActionResult AcceptContacts(UserContactViewModel contacts)
        {
            var errorsResult = contacts.IsValid();
            if (errorsResult != null)
            {
                foreach (var error in errorsResult)
                {
                    ModelState.AddModelError("", error);
                }
            }
            if (ModelState.IsValid)
            {
                var userDb = userManager.GetUserAsync(HttpContext.User).Result;
                userDb.ChangeContactsUser(contacts);
                userManager.UpdateAsync(userDb).Wait();
                return View("Contacts", userDb.ToUserViewModel());
            }
            return View("AddContacts", contacts);
        }
        public IActionResult Favorites()
        {
            var userDb = userManager.GetUserAsync(HttpContext.User).Result;
            ViewBag.Favorites = favoritesRepository.TryGetByUserId(userDb.UserName);
            return View(userDb.ToUserViewModel());
        }
    }
}
