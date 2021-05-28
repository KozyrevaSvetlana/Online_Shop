using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUsersRepository usersRepository;
        private readonly IFavoritesRepository favoritesRepository;

        public ProfileController(IUsersRepository usersRepository, IFavoritesRepository favoritesRepository)
        {
            this.usersRepository = usersRepository;
            this.favoritesRepository = favoritesRepository;
        }
        public IActionResult Index(string name)
        {
            return View(usersRepository.GetUserByName(name));
        }
        public IActionResult Orders(string name)
        {
            var user = usersRepository.GetUserByName(name);

            return View(user);
        }
        public IActionResult Contacts(string name)
        {
            var user = usersRepository.GetUserByName(name);

            return View(user);
        }
        public IActionResult AddContacts(string userName)
        {
            ViewData["Name"] = userName;
            return View();
        }

        [HttpPost]
        public IActionResult AcceptContacts(UserContact userContacts, string userName)
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
                var user = usersRepository.GetUserByName(userName);
                user.AddContacts(userContacts);
                return View("Contacts", user);
            }
            return View("Contacts");
        }
        public IActionResult Favorites(string name)
        {
            var user = usersRepository.GetUserByName(name);
            ViewBag.Favorites = favoritesRepository.TryGetByUserId(Constants.UserId);
            return View(user);
        }
    }
}
