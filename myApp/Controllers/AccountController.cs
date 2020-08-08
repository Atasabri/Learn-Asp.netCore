using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using myApp.Models;
using myApp.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace myApp.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;
        private ILogger<AccountController> _logger;

        public AccountController(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager,ILogger<AccountController>logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }
        /// <summary>
        /// Register And Login
        /// </summary>
        /// <returns></returns>
        public IActionResult Register()
        {
            return View();
        }

        [AcceptVerbs("Get","Post")]
        public async Task<IActionResult> IsEmailUsed(string email)
        {
            var user =await _userManager.FindByEmailAsync(email);
            if(user==null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email {email} Is Used !!");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = new IdentityUser() { UserName = model.Email,Email=model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if(result.Succeeded)
                {
                    //Confirm Email URL
                    var Token =await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var url = Url.Action("ConfirmEmail", "Account", new {UserID=user.Id,token=Token });
                    _logger.LogInformation(url);

                    if(_signInManager.IsSignedIn(User)&&User.IsInRole("admin"))
                    {
                        return RedirectToAction("Index", "Account");
                    }
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.Code, item.Description);
                }
            }
            return View();
        }


        public async Task<IActionResult> Login()
        {
            LoginViewModel loginViewModel = new LoginViewModel
            {
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };
            return View(loginViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string ReturnUrl = null)
        {
            model.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, true);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                        //return LocalRedirect(ReturnUrl); // Redirect to Return Url And Throw Exception If Not Local
                    }
                    return RedirectToAction("Index", "Home");
                }else if(result.IsLockedOut)
                {
                    ModelState.AddModelError(string.Empty, "Your Account Is Locked Please Wait ...");
                }
                ModelState.AddModelError(string.Empty, "InValid Login !!");
            }
            return View(model);
        }

        /// <summary>
        /// External Logins
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ExternalLogin(string provider)
        {
            var redirectUrl = Url.Action("ExternalLoginCallBack", "Account");

            var properites = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properites);
        }

        public async Task<IActionResult> ExternalLoginCallBack(string returnUrl = null , string remoteError = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if(remoteError == null)
            {
                var info = await _signInManager.GetExternalLoginInfoAsync();
                if (info != null)
                {
                    var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false, true);
                    if (!result.Succeeded)
                    {
                        var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                        var user = await _userManager.FindByEmailAsync(email);
                        if(user == null)
                        {
                            user = new IdentityUser() { UserName = email, Email = email };
                            await _userManager.CreateAsync(user);
                        }
                        await _userManager.AddLoginAsync(user, info);
                        await _signInManager.SignInAsync(user,false);
                    }
                    return LocalRedirect(returnUrl);
                }
            }
            ModelState.AddModelError(string.Empty, "Error In External Login !");
            LoginViewModel loginViewModel = new LoginViewModel
            {
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };
            return View(nameof(Login),loginViewModel);
        }


        /// <summary>
        /// Email Confirmation
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> RequestConfirmEmail()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var Token =await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var url = Url.Action("ConfirmEmail", "Account", new { UserID = user.Id, token = Token });
            _logger.LogInformation(url);
            return Json(url);
        }
        public async Task<IActionResult> ConfirmEmail(string UserID,string Token)
        {
            var user = await _userManager.FindByIdAsync(UserID);
            var result = await _userManager.ConfirmEmailAsync(user, Token);
            if(result.Succeeded)
            {
                return RedirectToAction(nameof(Login));
            }
            return Content("error");
        }


        /// <summary>
        /// Forget And Reset Password
        /// </summary>
        /// <returns></returns>
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgetPassword(string Email)
        {
            var user = await _userManager.FindByEmailAsync(Email);
            if(user != null)
            {
                string Token = await _userManager.GeneratePasswordResetTokenAsync(user);
                string url = Url.Action("ResetPassword", "Account", new {Email = Email , Token = Token });
                return Content(url);
            }
            return View();
        }

        public IActionResult ResetPassword(string Email,string Token)
        {
            if(Email == null || Token == null)
            {
                ModelState.AddModelError("","Invalid Email Or Token !");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if(user != null)
            {
                var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
                if(result.Succeeded)
                {
                    if(await _userManager.IsLockedOutAsync(user))
                    {
                        await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.UtcNow);
                    }
                    return RedirectToAction(nameof(Login));
                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            else
            {
                ModelState.AddModelError("", "Email Not Found !");
            }        
            return View(model);
        }

        /// <summary>
        /// Change Password
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> ChangePassword()
        {
            var user = await _userManager.GetUserAsync(User);
            var hasPassword = await _userManager.HasPasswordAsync(user);
            var model = new ChangePasswordViewModel
            {
                HasPassword = hasPassword
            };
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            IdentityResult result = null;
            if (model.HasPassword)
            {
                result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            }
            else
            {
                result = await _userManager.AddPasswordAsync(user, model.NewPassword);
            }
            if (result.Succeeded)
            {
                await _signInManager.RefreshSignInAsync(user);
                return RedirectToAction("Index","Home");
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }
            var hasPassword = await _userManager.HasPasswordAsync(user);
            model.HasPassword = hasPassword;
            return View(model);
        }
        /// <summary>
        /// logout
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}
