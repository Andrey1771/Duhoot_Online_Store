using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShopDuhootWeb.Areas.Identity.Data;
using OnlineShopDuhootWeb.Models;
using System;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace OnlineShopDuhootWeb.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<OnlineShopDuhootWebUser> userManager;
        private readonly SignInManager<OnlineShopDuhootWebUser> signInManager;

        public AccountController(UserManager<OnlineShopDuhootWebUser> auserManager, SignInManager<OnlineShopDuhootWebUser> asigninManager)
        {
            userManager = auserManager;
            signInManager = asigninManager;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View(new LoginViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                OnlineShopDuhootWebUser user = await userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false/*TODO Добавить ограничения на вход*/);
                    if (result.Succeeded)
                    {
                        return Redirect(returnUrl ?? "/");
                    }
                }
                ModelState.AddModelError(nameof(LoginViewModel.UserName), "Неверный логин или пароль");
            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new OnlineShopDuhootWebUser() { /*UserName = model.UserName*/ };
                user.Email = model.Email;
                user.EmailConfirmed = false;

                user.UserName = user.Email;// Тк на данном сайте имя пользователя не указывается, то имя пользователя - это почта
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    MailAddress from = new MailAddress("register@duhoot.com", "Web Registration");
                    MailAddress to = new MailAddress(user.Email);
                    MailMessage m = new MailMessage(from, to);
                    m.Subject = "Email confirmation";
                    m.Body = string.Format("Для завершения регистрации перейдите по ссылке:" +
                                    "<a href=\"{0}\" title=\"Подтвердить регистрацию\">{0}</a>",
                        Url.Action("ConfirmEmail", "Account", new { Token = user.Id, Email = user.Email }, Request.Scheme));
                    m.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        try
                        {
                            // Файл должен содержать данные поля:
                            // Email
                            // Password
                            using (StreamReader reader = new StreamReader(@"LoginAndPassword.txt"))// TODO На настоящем сервере, этого не будет
                            {
                                string email = reader.ReadLine();
                                string password = reader.ReadLine();
                                smtp.Credentials = new NetworkCredential(email, password);
                            }
                        }
                        catch(FileNotFoundException)
                        {
                            Console.WriteLine("Письмо не было отправлено на почту, тк файл LoginAndPassword.txt не был найден");
                        }
                        catch
                        {
                            Console.WriteLine("Письмо не было отправлено на почту, тк возникла ошабка при считывании данных из LoginAndPassword.txt или из-за ошибки со стороны NetworkCredential");
                        }
                        
                        smtp.EnableSsl = true;
                        smtp.Send(m);
                    }

                    return RedirectToAction("Confirm", "Account", new { Email = user.Email });
                }
                else
                {
                    // AddErrors(result);
                }
            }
            return View(model);
        }

        [AllowAnonymous]
        public string Confirm(string Email)
        {
            return "На почтовый адрес " + Email + " Вам высланы дальнейшие" +
                    "инструкции по завершению регистрации";
        }

        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string Token, string Email)
        {
            OnlineShopDuhootWebUser user = await userManager.FindByIdAsync(Token);
            if (user != null)
            {
                if (user.Email == Email)
                {
                    user.EmailConfirmed = true;
                    await userManager.UpdateAsync(user);
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home", new { ConfirmedEmail = user.Email });
                }
                else
                {
                    return RedirectToAction("Confirm", "Account", new { Email = user.Email });
                }
            }
            else
            {
                return RedirectToAction("Confirm", "Account", new { Email = "" });
            }
        }
    }
}
