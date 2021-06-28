using Microsoft.AspNetCore.Http;
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
        private readonly ImagesProvider imagesProvider;

        public ProfileController(IFavoritesRepository favoritesRepository, IOrdersRepository ordersRepository, UserManager<User> userManager, ImagesProvider imagesProvider)
        {
            this.favoritesRepository = favoritesRepository;
            this.ordersRepository = ordersRepository;
            this.userManager = userManager;
            this.imagesProvider = imagesProvider;
        }
        public IActionResult Index()
        {
            var userDb = userManager.GetUserAsync(HttpContext.User).Result;
            return View(userDb.ToUserViewModel());
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
        public IActionResult ChangeProfileImage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ChangeProfileImage(IFormFile File)
        {
            var userDb = userManager.GetUserAsync(HttpContext.User).Result;
            var imagesPath = imagesProvider.SafeFile(File, ImageFolders.Profiles);
            userDb.Image = imagesPath;
            userManager.UpdateAsync(userDb).Wait();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteImage()
        {
            var userDb = userManager.GetUserAsync(HttpContext.User).Result;
            userDb.Image = "/img/profile.webp";
            userManager.UpdateAsync(userDb).Wait();
            return RedirectToAction("Index");
        }
    }
}
