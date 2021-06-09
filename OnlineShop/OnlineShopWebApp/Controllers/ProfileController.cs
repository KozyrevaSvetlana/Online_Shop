using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models.Interfaces;
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
        public IActionResult Index()
        {
            return View(usersRepository.GetUserByName(Constants.UserId));
        }
        public IActionResult Orders()
        {
            var user = usersRepository.GetUserByName(Constants.UserId);
            return View(user);
        }
        public IActionResult Contacts()
        {
            var user = usersRepository.GetUserByName(Constants.UserId);
            var emptyContacts = user.GetEmptyContacts();
            if (emptyContacts.Count!=0)
            {
                ViewBag.Empty = emptyContacts;
            }
            return View(user);
        }
        public IActionResult AddContacts()
        {
            ViewData["Name"] = Constants.UserId;
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
                var user = usersRepository.GetUserByName(Constants.UserId);
                user.AddContacts(userContacts);
                return View("Contacts", user);
            }
            return View("Contacts");
        }
        public IActionResult Favorites()
        {
            var user = usersRepository.GetUserByName(Constants.UserId);
            ViewBag.Favorites = favoritesRepository.TryGetByUserId(Constants.UserId);
            return View(user);
        }
    }
}
