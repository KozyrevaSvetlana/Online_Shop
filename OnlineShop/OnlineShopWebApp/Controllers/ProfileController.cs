using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ModelsLibrary.ModelsDto;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Helpers;
using ModelsLibrary.ModelsVM;
using System.Threading.Tasks;

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
        public async Task<IActionResult> IndexAsync()
        {
            var userDb = await userManager.GetUserAsync(HttpContext.User);
            return View(userDb.ToUserViewModel());
        }
        public async Task<IActionResult> OrdersAsync()
        {
            var userDb = await userManager.GetUserAsync(HttpContext.User);
            var orders = await ordersRepository.GetByUserId(userDb.UserName);
            var userVM = userDb.ToUserViewModel();
            userVM.Orders = orders.ToOrdersViewModels();
            return View(userVM);
        }
        public async Task<IActionResult> ContactsAsync()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var emptyContacts = user.ToUserViewModel().GetEmptyContacts();
            if (emptyContacts.Count != 0)
            {
                ViewBag.Empty = emptyContacts;
            }
            return View(user.ToUserViewModel());
        }
        public async Task<IActionResult> AddContactsAsync()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            return View(user.ToUserViewModel().Contacts);
        }

        [HttpPost]
        public async Task<IActionResult> AcceptContactsAsync(UserContactViewModel contacts)
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
                var userDb = await userManager.GetUserAsync(HttpContext.User);
                userDb.ChangeContactsUser(contacts);
                await userManager.UpdateAsync(userDb);
                return View("Contacts", userDb.ToUserViewModel());
            }
            return View("AddContacts", contacts);
        }
        public async Task<IActionResult> FavoritesAsync()
        {
            var userDb = await userManager.GetUserAsync(HttpContext.User);
            ViewBag.Favorites = favoritesRepository.GetByIdAsync(null, userDb.UserName);
            return View(userDb.ToUserViewModel());
        }
        public IActionResult ChangeProfileImage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangeProfileImageAsync(IFormFile File)
        {
            var userDb = await userManager.GetUserAsync(HttpContext.User);
            var imagesPath = imagesProvider.SafeFile(File, ImageFolders.Profiles);
            userDb.Image = imagesPath;
            await userManager.UpdateAsync(userDb);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteImage()
        {
            var userDb = await userManager.GetUserAsync(HttpContext.User);
            userDb.Image = "/img/profile.webp";
            await userManager.UpdateAsync(userDb);
            return RedirectToAction("Index");
        }
    }
}
