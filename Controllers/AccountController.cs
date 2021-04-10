using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShopDuhootWeb.Areas.Identity.Data;
using OnlineShopDuhootWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using System.Net;

namespace OnlineShopDuhootWeb.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        /// TODO Не уверен по поводу IdentityUser, Нужен DuhootUser?
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
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // наш email с заголовком письма
                    MailAddress from = new MailAddress("somemail@yandex.ru", "Web Registration");
                    // кому отправляем
                    MailAddress to = new MailAddress(user.Email);
                    // создаем объект сообщения
                    MailMessage m = new MailMessage(from, to);
                    // тема письма
                    m.Subject = "Email confirmation";
                    // текст письма - включаем в него ссылку
                    m.Body = string.Format("Для завершения регистрации перейдите по ссылке:" +
                                    "<a href=\"{0}\" title=\"Подтвердить регистрацию\">{0}</a>",
                        Url.Action("ConfirmEmail", "Account", new { Token = user.Id, Email = user.Email }, Request.Scheme/*Request.Url.Scheme*/));
                    m.IsBodyHtml = true;
                    // адрес smtp-сервера, с которого мы и будем отправлять письмо
                    SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 25);
                    // логин и пароль
                    smtp.Credentials = new NetworkCredential("somemail@yandex.ru", "password");
                    smtp.Send(m);
                    return RedirectToAction("Confirm", "Account", new { Email = user.Email });
                }
                else
                {
                    //AddErrors(result);
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
