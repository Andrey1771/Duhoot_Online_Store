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
using OnlineShopDuhootWeb.Service.EmailService.Abstract;

namespace OnlineShopDuhootWeb.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<OnlineShopDuhootWebUser> userManager;
        private readonly SignInManager<OnlineShopDuhootWebUser> signInManager;
        private readonly IMessageSender messageSender;

        public AccountController(UserManager<OnlineShopDuhootWebUser> auserManager, SignInManager<OnlineShopDuhootWebUser> asigninManager, IMessageSender amessageSender)
        {
            userManager = auserManager;
            signInManager = asigninManager;
            messageSender = amessageSender;
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
                    messageSender.SendEmail("register@duhoot.com", user.Email,
                        "Email confirmation", "Web Registration", string.Format("Для завершения регистрации перейдите по ссылке:" +
                        "<a href=\"{0}\" title=\"Подтвердить регистрацию\">{0}</a>",
                        Url.Action("ConfirmEmail", "Account", new { Token = user.Id, user.Email }, Request.Scheme))
                        );

                    return RedirectToAction("Confirm", "Account", new { user.Email });
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
            return "На почтовый адрес " + Email + " Вам высланы дальнейшие " +
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
                    return RedirectToAction("Confirm", "Account", new { user.Email });
                }
            }
            else
            {
                return RedirectToAction("Confirm", "Account", new { Email = "" });
            }
        }
    }
}
