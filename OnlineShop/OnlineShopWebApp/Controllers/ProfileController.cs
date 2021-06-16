using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
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

        public ProfileController(IUsersRepository usersRepository, IFavoritesRepository favoritesRepository, IOrdersRepository ordersRepository, UserManager<User> userManager)
        {
            this.favoritesRepository = favoritesRepository;
            this.ordersRepository = ordersRepository;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            return View(user.ToUserViewModel());
        }
        public IActionResult Orders()
        {
            var userDb = userManager.GetUserAsync(HttpContext.User).Result;
            var orders = ordersRepository.GetOrdersByUserId(userDb.UserName);
            userDb.ToUserViewModel().Orders = Mapping.ToOrdersViewModels(orders);
            return View(userDb);
        }
        public IActionResult Contacts()
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            var emptyContacts = user.ToUserViewModel().GetEmptyContacts();
            if (emptyContacts.Count != 0)
            {
                ViewBag.Empty = emptyContacts;
            }
            return View(user);
        }
        public IActionResult AddContacts()
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            ViewData["Name"] = user.UserName;
            return View();
        }

        [HttpPost]
        public IActionResult AcceptContacts(UserContactViewModel userContacts)
        {
            var errorsResult = userContacts.IsValid();
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
                //сделать метод добавления контактов к юзеру
                return View("Contacts", userDb);
            }
            return View("Contacts");
        }
        public IActionResult Favorites()
        {
            var userDb = userManager.GetUserAsync(HttpContext.User).Result;
            ViewBag.Favorites = favoritesRepository.TryGetByUserId(userDb.UserName);
            return View(userDb.ToUserViewModel());
        }
    }
}
