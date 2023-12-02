using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ModelsLibrary.ModelsDto;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Helpers;
using ModelsLibrary.ModelsVM;
using System;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IOrdersRepository ordersRepository;
        private readonly IMailService emailService;

        public LoginController(UserManager<User> userManager, SignInManager<User> signInManager, IOrdersRepository ordersRepository, IMailService emailService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.ordersRepository = ordersRepository;
            this.emailService = emailService;
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
                var user = await userManager.FindByEmailAsync(login.Email);
                if (user == null)
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                    return View("Index", login);
                }
                if (!await userManager.IsEmailConfirmedAsync(user))
                {
                    ModelState.AddModelError(string.Empty, "Вы не подтвердили свой email");
                    var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    await SendConfimLetter(login.Email, user, code);
                    return View("Index", login);
                }
                var result = await signInManager.PasswordSignInAsync(login.Email, login.Password, login.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                    return View("Index", login);
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
            if (register.Email == register.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать!");
            }
            if (ModelState.IsValid)
            {
                var checkUser = await userManager.FindByEmailAsync(register.Email);
                if (checkUser != null)
                {
                    ModelState.AddModelError("", "Пользователь с таким email уже существует. Авторизуйтесь");
                    return View("RegIndex", register);
                }
                checkUser = await userManager.FindByNameAsync(register.Email);
                if (checkUser != null)
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует. Авторизуйтесь");
                    return View("RegIndex", register);
                }

                var user = new User { UserName = register.Email, Email = register.Email };
                var result = await userManager.CreateAsync(user, register.Password);
                if (result.Succeeded)
                {
                    try
                    {
                        var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
                        await SendConfimLetter(register.Email, user, code);
                        return View("ConfirmEmail");
                    }
                    catch (Exception)
                    {
                        ModelState.AddModelError("", $"Во время отправки письма на почту {register.Email} произошла ошибка.Проверьте адрес почты");
                        await userManager.DeleteAsync(user);
                        return View("RegIndex", register);
                    }
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
                return RedirectToAction("Index");
            return View("Error");
        }

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
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Такая почта не зарегистрирована");
                    return View(model);
                }
                if (!await userManager.IsEmailConfirmedAsync(user))
                {
                    ModelState.AddModelError(string.Empty, "Ваша почта не подтверждена. На нее отправлено письмо со ссылкой для подтверждения");
                    var confirmCode = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    await SendConfimLetter(model.Email, user, confirmCode);
                    return View(model);
                }
                var code = await userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.Action("ResetPassword", "Login", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
                await emailService.SendEmailAsync(model.Email, "Сброс пароля", $"Для сброса пароля пройдите <a href='{callbackUrl}'>по ссылке</a>");
                return View("ForgotPasswordConfirmation");
            }
            return View(model);
        }

        public IActionResult ResetPassword(string code)
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

        private async Task SendConfimLetter(string email, User user, string code)
        {
            var callbackUrl = Url.Action("ConfirmEmail", "Login",
                new
                {
                    userId = user.Id,
                    code = code
                },
                protocol: HttpContext.Request.Scheme);
            await emailService.SendEmailAsync(email, "Подтвердите свой профиль",
                $"Подтвердите регистрацию, перейдя <a href='{callbackUrl}'>по ссылке</a>");
        }
    }
}
