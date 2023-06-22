using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IOrdersRepository ordersRepository;

        public LoginController(UserManager<User> userManager, SignInManager<User> signInManager, IOrdersRepository ordersRepository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.ordersRepository = ordersRepository;
        }

        [HttpGet]
        public IActionResult Index(string returnUrl)
        {
            if (returnUrl != null)
            {
                return View(new Login() { ReturnUrl = returnUrl });
            }
            return View();
        }
        public IActionResult RegIndex(string returnUrl)
        {
            if (returnUrl != null)
            {
                return View(new Register() { ReturnUrl = returnUrl });
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckInAsync(Login login)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(login.Name);
                if (user != null)
                {
                    // проверяем, подтвержден ли email
                    if (!await userManager.IsEmailConfirmedAsync(user))
                    {
                        ModelState.AddModelError(string.Empty, "Вы не подтвердили свой email");
                        return View(login);
                    }
                }
                var result = await signInManager.PasswordSignInAsync(login.Name, login.Password, login.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }

                if (login.ReturnUrl == null)
                {
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
                return Redirect(login.ReturnUrl);
            }
            return View("Index", login);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(Register register)
        {
            if (register.Name == register.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать!");
            }
            if (ModelState.IsValid)
            {
                User user = new User { UserName = register.Name, Email = register.Email };
                var result = await userManager.CreateAsync(user, register.Password);
                if (result.Succeeded)
                {
                    var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Action("ConfirmEmail", "Login",
                        new
                        {
                            userId = user.Id,
                            code = code
                        },
                        protocol: HttpContext.Request.Scheme);

                    var emailService = new EmailService();
                    await emailService.SendEmailAsync(register.Email, "Подтвердите ваш профиль", $"Подтвердите регистрацию, перейдя по <a href='{callbackUrl}'>ссылке</a>");
                    return View("ConfirmEmail");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                        return View("RegIndex", register);
                    }
                }
            }
            return View("RegIndex", register);
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
                return View("Error");
            var user = await userManager.FindByIdAsync(userId);
            if (user == null || user.EmailConfirmed)
                return View("Error");
            var result = await userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
                return RedirectToAction("Index", "Home");
            else
                return View("Error");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user == null || !(await userManager.IsEmailConfirmedAsync(user)))
                    return View("ForgotPasswordConfirmation");
                var code = await userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.Action("ResetPassword", "Login", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
                var emailService = new EmailService();
                await emailService.SendEmailAsync(model.Email, "Сброс пароля", $"Для сброса пароля пройдите по ссылке: <a href='{callbackUrl}'>link</a>");
                return View("ForgotPasswordConfirmation");
            }
            return View(model);
        }

        public IActionResult ResetPassword(string code = null)
        {
            return code == null ? View("Error") : View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return View("ResetPasswordConfirmation");
            var confirmPasswords = await userManager.CheckPasswordAsync(user, model.Password);
            if (confirmPasswords)
            {
                ModelState.AddModelError(string.Empty, "Старый пароль не должен совпадать с новым. Введите новый пароль или зайдите под старым");
                return View(model);
            }
            var result = await userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded)
                return View("Index");
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }
    }
}
